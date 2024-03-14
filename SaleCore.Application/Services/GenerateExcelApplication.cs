using SaleCore.Application.Interfaces;
using SaleCore.Infrastructure.FileExcel;
using SaleCore.Utilities.Static;

namespace SaleCore.Application.Services
{
    public class GenerateExcelApplication : IGenerateExcelApplication
    {
        private readonly IGenerateExcel _generateExcel;

        public GenerateExcelApplication(IGenerateExcel generateExcel)
        {
            _generateExcel = generateExcel;
        }

        public byte[] GenerateToExcel<T>(IEnumerable<T> data, List<(string ColumnName, string PropertyName)> columns)
        {
            var excelColumns = ExcelColumnsNames.GetColumns(columns);
            var memoryStreamExcel = _generateExcel.GenerateToExcel(data, excelColumns);
            var fileBytes = memoryStreamExcel.ToArray();

            return fileBytes;
        }
    }
}