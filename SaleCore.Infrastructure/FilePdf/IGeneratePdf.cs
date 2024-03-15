using System.Globalization;

namespace SaleCore.Infrastructure.FilePdf
{
    public interface IGeneratePdf
    {
        MemoryStream GenerateToPdf(string title, string content);
    }
}