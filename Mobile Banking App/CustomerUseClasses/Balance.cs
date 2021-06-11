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
        internal static void ViewBalance(ICustomer customer)
        {
            if (Convert.ToString(customer.GetType()) == "ClassLibrary.Customer.CurrentCustomer")
            {
                if(customer.Account.balance < 0)
                {
                    Console.WriteLine($"The balance in your account is {customer.Account.balance}");
                    Console.WriteLine("Note: The negative balance shows the amount overdrawn from your account");
                }
            }
            else
                Console.WriteLine($"The balance in your account is {customer.Account.balance}");
        }
    }
}
