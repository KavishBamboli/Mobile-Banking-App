using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    internal class SaveChangesToFile
    {
        internal static void Save(int accNo, int balance, AccountType type)
        {
            FileInfo file = new FileInfo(@"D:\Programming Projects\Mobile Banking App\Customers.xlsx");

            using(var package = new ExcelPackage(file))
            {
                ExcelWorksheet ws;
                if (type == AccountType.Savings)
                    ws = package.Workbook.Worksheets[0];
                else
                    ws = package.Workbook.Worksheets[1];

                int row = 3;
                while(string.IsNullOrEmpty(ws.Cells[row, 1].Value?.ToString()) == false)
                {
                    if (int.Parse(ws.Cells[row, 5].Value.ToString()) == accNo)
                        break;
                    else
                        row += 1;
                }
                ws.Cells[row, 6].Value = balance;

                package.Save();
            }
        }

        internal static void Save(int accNo, int balance, int OverdraftBalance)
        {
            FileInfo file = new FileInfo(@"D:\Programming Projects\Mobile Banking App\Customers.xlsx");

            using (var package = new ExcelPackage(file))
            {
                var ws = package.Workbook.Worksheets[1];

                int row = 3;
                while (string.IsNullOrEmpty(ws.Cells[row, 1].Value?.ToString()) == false)
                {
                    if (int.Parse(ws.Cells[row, 5].Value.ToString()) == accNo)
                        break;
                    else
                        row += 1;
                }
                ws.Cells[row, 6].Value = balance;
                ws.Cells[row, 7].Value = OverdraftBalance;

                package.Save();
            }
        }
    }
}