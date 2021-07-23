using ClassLibrary;
using ClassLibrary.Customer;
using OfficeOpenXml;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MobileBankingApplication
{
    public class RetrieveCustomer
    {
        public static T Retrieve<T>(int accNo, AccountType type, out int row) where T : ICustomer
        {
            FileInfo file = new FileInfo(@"D:\Programming Projects\Mobile Banking App\Customers.xlsx");

            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet ws;

                if (type == AccountType.Savings)
                    ws = package.Workbook.Worksheets[0];

                else
                    ws = package.Workbook.Worksheets[1];

                row = 3;

                while(string.IsNullOrWhiteSpace(ws.Cells[row, 1].Value?.ToString()) == false)
                {
                    if(int.Parse(ws.Cells[row, 5].Value.ToString()) == accNo)
                    {
                        var c = WireCustomerData.Wire<T>(ws, row, type);
                        return c;
                    }
                    row += 1;
                }
            }
            row = 0;
            return default(T);
        }
    }
}
