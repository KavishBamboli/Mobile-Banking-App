using Autofac;
using ClassLibrary.Account;
using ClassLibrary.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankingApplication.CustomerUseClasses
{
    internal static class Balance
    {
        public delegate void ViewBalance(ISavingsAccount account);

        internal static void View(ViewBalance balance, ICustomer customer)
        {
            balance(customer.Account);
        }
    }
}
