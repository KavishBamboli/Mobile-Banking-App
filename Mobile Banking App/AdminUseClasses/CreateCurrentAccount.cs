using ClassLibrary;
using ClassLibrary.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankingApplication.AdminUseClasses
{
    internal class CreateCurrentAccount
    {
        ICurrentCustomer _customer;

        public CreateCurrentAccount(ICurrentCustomer customer)
        {
            _customer = customer;
        }
        internal void Create()
        {
            Console.WriteLine("Enter business name: ");
            _customer.Name = Console.ReadLine();

            Console.WriteLine("Enter owner name: ");
            _customer.OwnerName = Console.ReadLine();

            do
            {
                Console.WriteLine("Enter customer email: ");
                _customer.Email = Console.ReadLine();

            } while (!EmailValidator.Validate(_customer.Email));

            _customer.LoginPin = LoginPinGenerator.GeneratePin();
            _customer.Account.accNo = AccountNumberGenerator.GenerateAccountNumber(AccountType.Savings);

            Console.WriteLine("\nAccount created successfully");

            //Function call to save account details into the file
        }
    }
}
