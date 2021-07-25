using ClassLibrary.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankingApplication.CustomerUseClasses
{
    public static class TransferMoney
    {
        public static bool Transfer<T, U>(T customer, U beneficiaryCustomer) where T : ICustomer where U : ICustomer
        {
            if (beneficiaryCustomer == null)
            {
                Console.WriteLine("Account not found");
                return false;
            }

            else
            {
                Console.WriteLine("The balance in your account is " + customer.Account.balance);
                Console.WriteLine();
                Console.WriteLine("Enter amount to transfer");
                int amount = Convert.ToInt32(Console.ReadLine());

                if (amount > 20000)
                {
                    Console.WriteLine("Transfer failed as amount exceeded the maximum limit");
                    return false;
                }

                else
                {
                    if (customer.Account.MakeWithdrawal(amount, $"Transferred money to account {beneficiaryCustomer.Account.accNo}") == false)
                    {
                        Console.WriteLine("Transfer failed due to insufficient balances");
                        return false;
                    }    
                    beneficiaryCustomer.Account.MakeDeposit(amount, $"Received money from {customer.Account.accNo}");

                    return true;
                }
            }
        }
    }
}
