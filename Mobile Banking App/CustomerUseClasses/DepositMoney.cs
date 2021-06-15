using ClassLibrary.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankingApplication.CustomerUseClasses
{
    internal static class DepositMoney
    {
        internal static bool Deposit(ICustomer customer)
        {
            Console.WriteLine("Enter amount to deposit");
            int amount = Convert.ToInt32(Console.ReadLine());

            return customer.Account.MakeDeposit(amount, "Deposited money into account");
        }
    }
}
