using ClassLibrary.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankingApplication.CustomerUseClasses
{
    internal static class ViewCurrentAccountBalance
    {
        public static void ViewBalance(IAccount account)
        {
            ICurrentAccount acc = (ICurrentAccount)account;

            if (account.balance < 0)
            {
                Console.WriteLine($"The balance in your account is {acc.balance}");
                Console.WriteLine($"The overdraft balance in your account is {acc.TotalOverdraftBalance} ");
            }
            else
                Console.WriteLine($"The balance in your account is {acc.balance}");
        }
    }
}
