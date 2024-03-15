using Microsoft.AspNetCore.Mvc;
using SaleCore.Application.Commons.Bases.Request;
using SaleCore.Application.Dtos.Purcharse.Request;
using SaleCore.Application.Interfaces;
using SaleCore.Utilities.Static;

namespace SaleCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurcharseController : ControllerBase
    {
        private readonly IPurcharseApplication _purcharseApplication;
        private readonly IGenerateExcelApplication _generateExcelApplication;

        public PurcharseController(IPurcharseApplication purcharseApplication, IGenerateExcelApplication generateExcelApplication)
        {
            _purcharseApplication = purcharseApplication;
            _generateExcelApplication = generateExcelApplication;
        }

        [HttpGet]
        public async Task<IActionResult> ListPurcharses([FromQuery] BaseFiltersRequest filters)
        {
            var response = await _purcharseApplication.ListPurcharses(filters);

            if ((bool)filters.Download!)
            {
                var columnNames = ExcelColumnsNames.GetColumnsPurcharses();
                var fileBytes = _generateExcelApplication.GenerateToExcel(response.Data!, columnNames);
                return File(fileBytes, ContentType.ContentTypeExcel);
            }

            return Ok(response);
        }

        [HttpGet("{purcharseId:int}")]
        public async Task<IActionResult> PurcharseById(int purcharseId)
        {
            var response = await _purcharseApplication.PurcharseById(purcharseId);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterPurcharse([FromBody] PurcharseRequestDto requestDto)
        {
            var response = await _purcharseApplication.RegisterPurcharse(requestDto);
            return Ok(response);
        }

        [HttpPut("Cancel/{purcharseId:int}")]
        public async Task<IActionResult> CancelPurcharse(int purcharseId)
        {
            var reponse = await _purcharseApplication.CancelPurcharse(purcharseId);
            return Ok(reponse);
        }
    }
}