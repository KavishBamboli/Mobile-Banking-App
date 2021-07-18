using Autofac;
using ClassLibrary;
using ClassLibrary.Account;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBankingApplication
{
    internal static class LoadCustomerData
    {
        internal static async Task<List<T>> Load<T>(Stream stream, AccountType type)
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

            var container = ContainerConfig.Configure();

            while (string.IsNullOrWhiteSpace(ws.Cells[row, col].Value?.ToString()) == false)
            {
                using (var scope = container.BeginLifetimeScope())
                {
                    var c = scope.Resolve<T>();

                    var prop = c.GetType().GetProperties();

                    if (type == AccountType.Savings)
                    {
                        var account = scope.Resolve<IAccount>();
                        account.accNo = int.Parse(ws.Cells[row, col + 4].Value.ToString());
                        account.balance = int.Parse(ws.Cells[row, col + 5].Value.ToString());
                        prop[prop.Length - 1].SetValue(c, account);
                    }
                    else if (type == AccountType.Current)
                    {
                        var account = scope.Resolve<ICurrentAccount>();
                        account.accNo = int.Parse(ws.Cells[row, col + 4].Value.ToString());
                        account.balance = int.Parse(ws.Cells[row, col + 5].Value.ToString());
                        prop[prop.Length - 1].SetValue(c, account);
                    }

                    for (int i = 0; i < prop.Length - 1; i++)
                    {
                        if (prop[i].PropertyType == Type.GetType("System.String"))
                            prop[i].SetValue(c, ws.Cells[row, col + i].Value.ToString());
                        else
                            prop[i].SetValue(c, int.Parse(ws.Cells[row, col + i].Value.ToString()));
                    }

                    output.Add(c);

                    row += 1;
                }
            }

            return output;
        }
    }
}
