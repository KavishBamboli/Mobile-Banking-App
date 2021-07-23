using ClassLibrary;
using ClassLibrary.Customer;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankingApplication.AdminUseClasses
{
    public static class DeleteAccount
    {
        public static void Delete<T>(int accNo, AccountType type) where T : ICustomer
        {
            int row;
            var customer = RetrieveCustomer.Retrieve<T>(accNo, type, out row);

            FileInfo file = new FileInfo(@"D:\Programming Projects\Mobile Banking App\Customers.xlsx");

            if (customer != null && row != 0)
            {
                using (var package = new ExcelPackage(file))
                {
                    ExcelWorksheet ws;
                    if (type == AccountType.Savings)
                        ws = package.Workbook.Worksheets[0];
                    else
                        ws = package.Workbook.Worksheets[1];

                    int col = 1;

                    for (int i = 0; i < 6; i++)
                    {
                        ws.Cells[row, col + i].Value = "deleted";
                    }

                    package.Save();
                }
                Console.WriteLine("Account deleted successfully");
            }
            else
                Console.WriteLine("Account not found");
        }
    }
}
