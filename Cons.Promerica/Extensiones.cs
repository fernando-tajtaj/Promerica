namespace Cons.Promerica
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;
    internal static class Extensiones
    {
        public static string ToStringDataSet(this DataSet ds)
        {
            var sb = new StringBuilder();
            foreach (var table in ds.Tables.ToList())
            {
                sb.AppendLine("--" + table.TableName + "--");
                sb.AppendLine(String.Join(" | ", table.Columns.ToList()));
                foreach (DataRow row in table.Rows)
                {
                    sb.AppendLine(String.Join(" | ", row.ItemArray));
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public static List<DataTable> ToList(this DataTableCollection collection)
        {
            var list = new List<DataTable>();
            foreach (var table in collection)
            {
                list.Add((DataTable)table);
            }
            return list;
        }

        public static List<DataColumn> ToList(this DataColumnCollection collection)
        {
            var list = new List<DataColumn>();
            foreach (var column in collection)
            {
                list.Add((DataColumn)column);
            }
            return list;
        }
    }
}
