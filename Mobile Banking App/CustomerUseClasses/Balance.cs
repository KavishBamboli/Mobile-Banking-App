using Autofac;
using ClassLibrary.Account;
using ClassLibrary.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Banking_App.CustomerUseClasses
{
    internal static class Balance
    {
        public delegate void ViewBalance(IAccount account);

        internal static void View(ViewBalance balance, ICustomer customer)
        {
            balance(customer.Account);
        }
    }
}
