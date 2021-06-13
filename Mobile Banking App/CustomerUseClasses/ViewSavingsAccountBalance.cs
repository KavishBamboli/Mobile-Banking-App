using ClassLibrary.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Banking_App.CustomerUseClasses
{
    internal static class ViewSavingsAccountBalance
    {
        internal static void ViewBalance(IAccount account)
        {
            Console.WriteLine($"The balance in your account is {account.balance} ");
        }
    }
}
