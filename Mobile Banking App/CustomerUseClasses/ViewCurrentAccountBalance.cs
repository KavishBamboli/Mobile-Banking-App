using ClassLibrary.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Banking_App.CustomerUseClasses
{
    internal static class ViewCurrentAccountBalance
    {
        public static void ViewBalance(IAccount account)
        {
            if (account.balance < 0)
            {
                ICurrentAccount account1 = (ICurrentAccount)account;

                Console.WriteLine($"The balance in your account is {account1.balance}");
                Console.WriteLine($"The overdraft balance in your account is {account1.TotalOverdraftBalance} ");
            }
            else
                Console.WriteLine($"The balance in your account is {account.balance}");
        }
    }
}
