using Autofac;
using ClassLibrary;
using ClassLibrary.Account;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankingApplication
{
    public class WireCustomerData
    {
        public static T Wire<T>(ExcelWorksheet ws, int row, AccountType type)
        {
            var container = ContainerConfig.Configure();

            T c;
            int col = 1;
            using(var scope = container.BeginLifetimeScope())
            {
                c = scope.Resolve<T>();

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
            }
            return c;
        }
    }
}
