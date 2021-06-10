using ClassLibrary.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Banking_App
{
    internal class ApplicationForCustomer
    {
        ICustomer _savingsCustomer;
        ICustomer _currentCustomer;

        public ApplicationForCustomer(ISavingsCustomer savingsCustomer, ICurrentCustomer currentCustomer)
        {
            _savingsCustomer = savingsCustomer;
            _currentCustomer = currentCustomer;
        }

        internal void Run()
        {
            Menus.SecondaryCustomerMenu();

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            if (choice == 1)
            {
                _savingsCustomer = AuthenticateCustomer.Authenticate(_savingsCustomer);

                if (_savingsCustomer != null)
                {
                    Menus.TertiaryCustomerMenu();

                    int choice2 = Convert.ToInt32(Console.ReadLine());

                    UserChoice.CustomerChoice(choice2, _savingsCustomer);
                }

                else
                    Console.WriteLine("Invalid login pin");
            }

            else if (choice == 2)
            {
                _currentCustomer = AuthenticateCustomer.Authenticate(_currentCustomer);

                if (_currentCustomer != null)
                {
                    Menus.TertiaryCustomerMenu();

                    int choice2 = Convert.ToInt32(Console.ReadLine());

                    UserChoice.CustomerChoice(choice2, _currentCustomer);
                }

                else
                    Console.WriteLine("Invalid login pin");
            }

            else
                Console.WriteLine("Invalid selection");

        }
    }
}
