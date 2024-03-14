using Microsoft.Extensions.Configuration;
using SaleCore.Application.Interfaces;
using SaleCore.Utilities.AppSettings;
using SaleCore.Infrastructure.Persistences.Interfaces;
using Microsoft.Extensions.Options;
using SaleCore.Application.Commons.Bases.Response;
using SaleCore.Application.Dtos.User.Request;
using Microsoft.IdentityModel.Tokens;
using SaleCore.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SaleCore.Utilities.Static;
using BC = BCrypt.Net.BCrypt;
using WatchDog;
using Google.Apis.Auth;

namespace SaleCore.Application.Services
{
    public class AuthApplication : IAuthApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly AppSettings _appSettings;

        public AuthApplication(IUnitOfWork unitOfWork, IConfiguration configuration, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _appSettings = appSettings.Value;
        }

        public async Task<BaseResponse<string>> Login(TokenRequestDto requestDto, string authType)
        {
            var response = new BaseResponse<string>();

            try
            {
                var user = await _unitOfWork.User.UserByEmail(requestDto.Email!);

                if (user is null)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_TOKEN_ERROR;

                    return response;
                }

                if (user.AuthType != authType)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_AUTH_TYPE_GOOGLE;

                    return response;
                }

                if (BC.Verify(requestDto.Password, user.Password))
                {
                    response.IsSuccess = true;
                    response.Data = GenerateToken(user);
                    response.Message = ReplyMessage.MESSAGE_TOKEN;

                    return response;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
                WatchLogger.Log(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponse<string>> LoginWithGoogle(string credentials, string authType)
        {
            var response = new BaseResponse<string>();

            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>
                    {
                        _appSettings.ClientId!
                    }
                };

                var payload = await GoogleJsonWebSignature.ValidateAsync(credentials, settings);
                var user = await _unitOfWork.User.UserByEmail(payload.Email);

                if (user is null)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_GOOGLE_ERROR;

                    return response;
                }

                if (user.AuthType != authType)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_AUTH_TYPE;

                    return response;
                }

                response.IsSuccess = true;
                response.Data = GenerateToken(user);
                response.Message = ReplyMessage.MESSAGE_TOKEN;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
                WatchLogger.Log(ex.Message);
            }

            return response;
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]!));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Email!),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.UserName!),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Email!),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:Expires"]!)),
                notBefore: DateTime.UtcNow,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}