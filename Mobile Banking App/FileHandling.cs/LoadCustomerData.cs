using ClassLibrary;
using ClassLibrary.Customer;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MobileBankingApplication
{
    internal static class LoadCustomerData
    {
        internal static async Task<List<T>> Load<T>(Stream stream, AccountType type) where T : ICustomer
        {
            List<T> output = new List<T>();

            var package = new ExcelPackage(stream);

            await package.LoadAsync(stream);

            ExcelWorksheet ws;
            if (type == AccountType.Current)
                ws = package.Workbook.Worksheets[1];
            else
                ws = package.Workbook.Worksheets[0];

            int row = 3;
            int col = 1;

            while (string.IsNullOrWhiteSpace(ws.Cells[row, col].Value?.ToString()) == false)
            {
                if (ws.Cells[row, col].Value.ToString() == "deleted")
                {
                    row += 1;
                    continue;
                }

                var c = WireCustomerData.Wire<T>(ws, row, type);

                output.Add(c);

                row += 1;
            }
            return output;
        }
    }
}
