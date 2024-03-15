using Microsoft.AspNetCore.Mvc;
using SaleCore.Application.Commons.Bases.Request;
using SaleCore.Application.Dtos.Product.Request;
using SaleCore.Application.Interfaces;
using SaleCore.Utilities.Static;

namespace SaleCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductApplication _productApplication;
        private readonly IProductStockApplication _productStockApplication;
        private readonly IGenerateExcelApplication _generateExcelApplication;

        public ProductController(IProductApplication productApplication, IGenerateExcelApplication generateExcelApplication, IProductStockApplication productStockApplication)
        {
            _productApplication = productApplication;
            _generateExcelApplication = generateExcelApplication;
            _productStockApplication = productStockApplication;
        }

        [HttpGet]
        public async Task<IActionResult> ListProducts([FromQuery] BaseFiltersRequest filters)
        {
            var response = await _productApplication.ListProducts(filters);

            if ((bool)filters.Download!)
            {
                var columnNames = ExcelColumnsNames.GetColumnsProducts();
                var fileBytes = _generateExcelApplication.GenerateToExcel(response.Data!, columnNames);
                return File(fileBytes, ContentType.ContentTypeExcel);
            }

            return Ok(response);
        }

        [HttpGet("{productId:int}")]
        public async Task<IActionResult> ProductById(int productId)
        {
            var response = await _productApplication.ProductById(productId);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterProduct([FromForm] ProductRequestDto requestDto)
        {
            var response = await _productApplication.RegisterProduct(requestDto);
            return Ok(response);
        }

        [HttpPut("Edit/{productId:int}")]
        public async Task<IActionResult> EditProduct(int productId, [FromForm] ProductRequestDto requestDto)
        {
            var response = await _productApplication.EditProduct(productId, requestDto);
            return Ok(response);
        }

        [HttpPut("Remove/{productId:int}")]
        public async Task<IActionResult> RemoveProduct(int productId)
        {
            var response = await _productApplication.RemoveProduct(productId);
            return Ok(response);
        }

        [HttpGet("ProductStockByWarehouse/{productId:int}")]
        public async Task<IActionResult> ProductStockByWarehouse(int productId)
        {
            var response = await _productStockApplication
                .GetProductStockByWarehouseAsync(productId);
            return Ok(response);
        }
    }
}