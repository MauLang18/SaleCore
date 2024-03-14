using AutoMapper;
using LiteDB;
using Microsoft.Extensions.Configuration;
using SaleCore.Application.Commons.Bases.Response;
using SaleCore.Application.Dtos.User.Request;
using SaleCore.Application.Interfaces;
using SaleCore.Domain.Entities;
using SaleCore.Infrastructure.Persistences.Interfaces;
using SaleCore.Utilities.Static;
using BC = BCrypt.Net.BCrypt;

namespace SaleCore.Application.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IFileStorageLocalApplication _fileStorage;

        public UserApplication(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, IFileStorageLocalApplication fileStorage)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            _fileStorage = fileStorage;
        }

        public async Task<BaseResponse<bool>> RegisterUser(UserRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var account = _mapper.Map<User>(requestDto);
            account.Password = BC.HashPassword(account.Password);

            if (requestDto.Image is not null)
            {
                account.Image = await _fileStorage.SaveFile(AzureContainers.USERS, requestDto.Image);
            }

            response.Data = await _unitOfWork.User.RegisterAsync(account);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;
        }
    }
}