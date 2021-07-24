using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    internal class SaveTransactionToFile
    {
        internal static void Save(int accNo, ITransactions transaction)
        {
            FileInfo file = new FileInfo($@"D:\Programming Projects\Mobile Banking App\{accNo}.xlsx");

            using(var package = new ExcelPackage(file))
            {
                if(file.Exists)
                {

                    var ws = package.Workbook.Worksheets[0];
                    int row = 3;
                    while (string.IsNullOrWhiteSpace(ws.Cells[row, 1].Value?.ToString()) == false)
                        row += 1;

                    FillData(ws, row, transaction);
                }
                else
                {
                    var ws = package.Workbook.Worksheets.Add("Transactions");
                    ws.Cells[1, 1].Value = "ID";
                    ws.Cells[1, 2].Value = "Date";
                    ws.Cells[1, 3].Value = "Description";
                    ws.Cells[1, 4].Value = "Amount";
                    ws.Cells[1, 5].Value = "Type";

                    FillData(ws, 3, transaction);
                }

                package.Save();
            }
        }

        private static void FillData(ExcelWorksheet ws, int row, ITransactions transaction)
        {
            ws.Cells[row, 1].Value = transaction.TransactionId;
            ws.Cells[row, 2].Value = transaction.TransactionDate.ToShortDateString();
            ws.Cells[row, 3].Value = transaction.TransactionDescription;
            ws.Cells[row, 4].Value = transaction.Amount;
            ws.Cells[row, 5].Value = transaction.TransactonType;
        }
    }
}
