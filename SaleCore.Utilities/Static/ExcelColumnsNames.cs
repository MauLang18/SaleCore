namespace SaleCore.Utilities.Static
{
    public class ExcelColumnsNames
    {
        public static List<TableColumn> GetColumns(IEnumerable<(string ColumnName, string PropertyName)> columnsProperties)
        {
            var columns = new List<TableColumn>();

            foreach (var (ColumnName, PropertyName) in columnsProperties) 
            {
                var column = new TableColumn()
                {
                    Label = ColumnName,
                    PropertyName = PropertyName,
                };

                columns.Add(column);
            }

            return columns;
        }
    }
}