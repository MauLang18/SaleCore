using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaleCore.Application.Interfaces;

namespace SaleCore.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherDocumentTypeController : ControllerBase
    {
        private readonly IVoucherDocumentTypeApplication _voucherDocumentTypeApplication;

        public VoucherDocumentTypeController(IVoucherDocumentTypeApplication voucherDocumentTypeApplication)
        {
            _voucherDocumentTypeApplication = voucherDocumentTypeApplication;
        }

        [HttpGet]
        public async Task<IActionResult> ListVoucherDocumentTypes()
        {
            var response = await _voucherDocumentTypeApplication.ListVoucherDocumentTypes();
            return Ok(response);
        }
    }
}