using Microsoft.AspNetCore.Mvc;
using SaleCore.Application.Commons.Bases.Request;
using SaleCore.Application.Dtos.Sale.Request;
using SaleCore.Application.Interfaces;
using SaleCore.Utilities.Static;
using System.Globalization;

namespace SaleCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleApplication _saleApplication;
        private readonly IGenerateExcelApplication _generateExcelApplication;
        private readonly IGeneratePdfApplication _generatePdfApplication;

        public SaleController(ISaleApplication saleApplication, IGenerateExcelApplication generateExcelApplication, IGeneratePdfApplication generatePdfApplication)
        {
            _saleApplication = saleApplication;
            _generateExcelApplication = generateExcelApplication;
            _generatePdfApplication = generatePdfApplication;
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

        [HttpGet("Report/{saleId:int}")]
        public async Task<IActionResult> ReportSale(int saleId)
        {
            byte[] pdfBytes;
            string titulo = "";
            string contenidoPlantilla = "";
            string nombreArchivo = "";
            var response = await _saleApplication.SaleById(saleId);

            try
            {
                var data = response.Data;

                string rutaPlantilla = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Static/Template/Invoice", $"index.html");
                contenidoPlantilla = System.IO.File.ReadAllText(rutaPlantilla);
                titulo = "Factura"; // Título de la factura

                // Reemplazar datos de Fecha y Número de Factura
                contenidoPlantilla = contenidoPlantilla
                    .Replace("#fecha#", data!.DateOfSale.ToString("dd-MM-yyyy"))
                    .Replace("#factura#", data!.VoucherNumber);

                // Reemplazar datos del Cliente
                contenidoPlantilla = contenidoPlantilla
                    .Replace("#cliente#", data.ClientName)
                    .Replace("#direccion#", data.ClientAddress) 
                    .Replace("#telefono#", data.ClientPhone) 
                    .Replace("#correo#", data.ClientEmail); 

                // Iterar sobre detalles y llenar la tabla
                string detallesTabla = "";
                decimal subTotal = 0;

                foreach (var detalle in data.SaleDetails)
                {
                    subTotal += detalle.TotalAmount;

                    detallesTabla += $@"
            <tr>
                <td>{detalle.Name}</td>
                <td>{detalle.Code}</td>
                <td>{detalle.UnitSalePrice}</td>
                <td>{detalle.Quantity}</td>
                <td>{detalle.TotalAmount}</td>
            </tr>";
                }

                // Reemplazar datos de la tabla de detalles
                contenidoPlantilla = contenidoPlantilla
                    .Replace("<!--DetallesTabla-->", detallesTabla)
                    .Replace("#subTotal#", subTotal.ToString())
                    .Replace("#IVA#", data.Iva.ToString())
                    .Replace("#total#", data.TotalAmount.ToString());

                nombreArchivo = $"{data.VoucherNumber}-{data!.DateOfSale.ToString("dd-MM-yyyy")}-{data.ClientId}.pdf";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            pdfBytes = _generatePdfApplication.GenerateToPdf(titulo, contenidoPlantilla);

            return File(pdfBytes, "application/pdf", nombreArchivo);
        }

    }
}