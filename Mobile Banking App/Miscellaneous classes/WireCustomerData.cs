using Autofac;
using ClassLibrary;
using ClassLibrary.Customer;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace MobileBankingApplication
{
    public class WireCustomerData
    {
        public static T Wire<T>(ExcelWorksheet ws, int row, AccountType type) where T : ICustomer
        {
            var container = ContainerConfig.Configure();

            T c;
            int col = 1;
            using(var scope = container.BeginLifetimeScope())
            {
                c = scope.Resolve<T>();

                PropertyInfo[] prop = c.GetType().GetProperties();
                PropertyInfo[] accountProp = c.Account.GetType().GetProperties();

                for(int i = 0; i < accountProp.Length - 1; i++)
                {
                    if (accountProp[i].PropertyType == Type.GetType("System.String"))
                        accountProp[i].SetValue(c.Account, ws.Cells[row, 5 + i].ToString());
                    else
                        accountProp[i].SetValue(c.Account, int.Parse(ws.Cells[row, 5 + i].Value.ToString()));
                }

                var transactions = WireTransactionData(row, ws);
                accountProp[accountProp.Length - 1].SetValue(c.Account, transactions);

                for (int i = 0; i < prop.Length - 1; i++)
                {
                    if (prop[i].PropertyType == Type.GetType("System.String"))
                        prop[i].SetValue(c, ws.Cells[row, col + i].Value.ToString());
                    else
                        prop[i].SetValue(c, int.Parse(ws.Cells[row, col + i].Value.ToString()));
                }
            }
            return c;
        }

        private static List<ITransactions> WireTransactionData(int row, ExcelWorksheet ws)
        {
            List<ITransactions> output = new List<ITransactions>();
            int accNo = int.Parse(ws.Cells[row, 5].Value.ToString());

            FileInfo file = new FileInfo($@"D:\Programming Projects\Mobile Banking App\{accNo}.xlsx");

            if (file.Exists)
            {
                int trow = 3, tcol = 1;

                using (var package = new ExcelPackage(file))
                {
                    var tws = package.Workbook.Worksheets[0];

                    while (string.IsNullOrWhiteSpace(ws.Cells[trow, tcol].Value?.ToString()) == false)
                    {
                        Transactions t = new Transactions();

                        t.TransactionId = int.Parse(tws.Cells[trow, tcol].Value.ToString());
                        t.TransactionDate = Convert.ToDateTime(tws.Cells[trow, tcol + 1].Value);
                        t.TransactionDescription = tws.Cells[trow, tcol + 2].Value.ToString();
                        t.Amount = int.Parse(tws.Cells[trow, tcol + 3].Value.ToString());
                        t.TransactonType = tws.Cells[trow, tcol + 4].Value.ToString();

                        output.Add(t);
                        trow += 1;
                    }
                }
            }
            return output;
        }
    }
}
