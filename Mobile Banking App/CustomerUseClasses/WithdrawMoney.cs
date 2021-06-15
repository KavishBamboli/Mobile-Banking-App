using ClassLibrary.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankingApplication.CustomerUseClasses
{
    internal static class WithdrawMoney
    {
        internal static bool Withdraw(ICustomer customer)
        {
            Console.WriteLine("Enter amount to withdraw");
            int amount = Convert.ToInt32(Console.ReadLine());

            return customer.Account.MakeWithdrawal(amount, "Withdrew money from account");
        }
    }
}
