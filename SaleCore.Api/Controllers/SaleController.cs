using Microsoft.AspNetCore.Mvc;
using SaleCore.Application.Commons.Bases.Request;
using SaleCore.Application.Dtos.Sale.Request;
using SaleCore.Application.Interfaces;
using SaleCore.Utilities.Static;

namespace SaleCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleApplication _saleApplication;
        private readonly IGenerateExcelApplication _generateExcelApplication;

        public SaleController(ISaleApplication saleApplication, IGenerateExcelApplication generateExcelApplication)
        {
            _saleApplication = saleApplication;
            _generateExcelApplication = generateExcelApplication;
        }

        [HttpGet]
        public async Task<IActionResult> ListSales([FromQuery] BaseFiltersRequest filters)
        {
            var response = await _saleApplication.ListSales(filters);

            if ((bool)filters.Download!)
            {
                var columnNames = ExcelColumnsNames.GetColumnsSales();
                var fileBytes = _generateExcelApplication.GenerateToExcel(response.Data!, columnNames);
                return File(fileBytes, ContentType.ContentTypeExcel);
            }

            return Ok(response);
        }

        [HttpGet("{saleId:int}")]
        public async Task<IActionResult> SaleById(int saleId)
        {
            var response = await _saleApplication.SaleById(saleId);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterSale([FromBody] SaleRequestDto requestDto)
        {
            var response = await _saleApplication.RegisterSale(requestDto);
            return Ok(response);
        }

        [HttpPut("Cancel/{saleId:int}")]
        public async Task<IActionResult> CancelSale(int saleId)
        {
            var reponse = await _saleApplication.CancelSale(saleId);
            return Ok(reponse);
        }
    }
}