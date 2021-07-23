using ClassLibrary;
using ClassLibrary.Customer;
using OfficeOpenXml;
using System.IO;
using System.Threading.Tasks;

namespace MobileBankingApplication
{
    public class SaveCustomerData
    {
        public static async Task Save<T>(T customer, AccountType type) where T : ICustomer
        {
            FileInfo file = new FileInfo(@"D:\Programming Projects\Mobile Banking App\Customers.xlsx");

            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet ws;
                if (type == AccountType.Savings)
                    ws = package.Workbook.Worksheets[0];

                else
                    ws = package.Workbook.Worksheets[1];

                int row = 3, col = 1;

                while (string.IsNullOrWhiteSpace(ws.Cells[row, col].Value?.ToString()) == false)
                    row += 1;

                var prop = customer.GetType().GetProperties();

                for(int i = 0; i< prop.Length - 1; i++)
                {
                    ws.Cells[row, col].Value = prop[i].GetValue(customer);
                    col += 1;
                }

                ws.Cells[row, col].Value = customer.Account.accNo;
                ws.Cells[row, col + 1].Value = customer.Account.balance;

                await package.SaveAsync();
            }
        }
    }
}
