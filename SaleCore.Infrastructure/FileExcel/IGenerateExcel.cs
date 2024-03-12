using SaleCore.Utilities.Static;

namespace SaleCore.Infrastructure.FileExcel
{
    public interface IGenerateExcel
    {
        MemoryStream GenerateToExcel<T>(IEnumerable<T> data, List<TableColumn> columns);
    }
}