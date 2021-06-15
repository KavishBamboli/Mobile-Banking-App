using ClassLibrary.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankingApplication
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
                    int choice2;
                    do
                    {
                        Menus.TertiaryCustomerMenu();

                        choice2 = Convert.ToInt32(Console.ReadLine());

                        UserChoiceHandler.CustomerChoice(choice2, _savingsCustomer);
                    } while (choice2 != 6);
                }

                else
                    Console.WriteLine("Invalid login pin");
            }

            else if (choice == 2)
            {
                _currentCustomer = AuthenticateCustomer.Authenticate(_currentCustomer);

                int choice2;

                if (_currentCustomer != null)
                {
                    do
                    {
                        Menus.TertiaryCustomerMenu();

                        choice2 = Convert.ToInt32(Console.ReadLine());

                        UserChoiceHandler.CustomerChoice(choice2, _currentCustomer);
                    } while (choice2 != 6);
                }

                else
                    Console.WriteLine("Invalid login pin");
            }

            else
                Console.WriteLine("Invalid selection");

        }
    }
}
