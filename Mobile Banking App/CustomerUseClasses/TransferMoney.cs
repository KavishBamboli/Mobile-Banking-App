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
        public static bool Transfer<T>(T customer) where T : ICustomer
        {
            Console.WriteLine("Enter beneficiary account number: ");
            int accNo = Convert.ToInt32(Console.ReadLine());

            ICustomer beneficiaryAccount = getCustomer(accNo);

            if (beneficiaryAccount == null)
            {
                Console.WriteLine("Account not found");
                return false;
            }

            else
            {
                Console.WriteLine("Enter amount to transfer");
                int amount = Convert.ToInt32(Console.ReadLine());

                if (amount > 50000)
                {
                    Console.WriteLine("Transfer failed as amount exceeded the maximum limit");
                    return false;
                }

                else
                {
                    customer.Account.MakeWithdrawal(amount, $"Transferred money to account {accNo}");
                    beneficiaryAccount.Account.MakeDeposit(amount, $"Received money from {accNo}");

                    return true;
                }
            }
        }

        private static ICustomer getCustomer(int accNo)
        {
            //code to get the customer from the account number from the file.
            return null;
        }
    }
}
