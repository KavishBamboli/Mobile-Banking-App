using ClassLibrary;
using ClassLibrary.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankingApplication.AdminUseClasses
{
    class CreateSavingsAccount
    {
        ISavingsCustomer _customer;

        public CreateSavingsAccount(ISavingsCustomer customer)
        {
            _customer = customer;
        }

        public void Create()
        {
            Console.WriteLine("Enter customer name: ");
            _customer.Name = Console.ReadLine();

            Console.WriteLine("Enter customer age: ");
            _customer.Age = Convert.ToInt32(Console.ReadLine());

            do
            {
                Console.WriteLine("Enter customer email: ");
                _customer.Email = Console.ReadLine();

            } while (!EmailValidator.Validate(_customer.Email));

            _customer.LoginPin = LoginPinGenerator.GeneratePin();
            _customer.Account.accNo = AccountNumberGenerator.GenerateAccountNumber(AccountType.Savings);
            _customer.Account.MakeDeposit(1500, "Initial deposit");

            Console.WriteLine("\nAccount created successfully");

            //Function call to save the account details to file.
        }
    }
}
