using SaleCore.Application.Interfaces;
using SaleCore.Infrastructure.FilePdf;

namespace SaleCore.Application.Services
{
    public class GeneratePdfApplication : IGeneratePdfApplication
    {
        private readonly IGeneratePdf _generatePdf;

        public GeneratePdfApplication(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }

        public byte[] GenerateToPdf(string titulo, string content)
        {
            var memoryStreamExcel = _generatePdf.GenerateToPdf(titulo, content);
            var fileBytes = memoryStreamExcel.ToArray();

            return fileBytes;
        }
    }
}