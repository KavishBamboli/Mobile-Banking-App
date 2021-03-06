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
        ISavingsCustomer _savingsCustomer;
        ICurrentCustomer _currentCustomer;

        public ApplicationForCustomer(ISavingsCustomer savingsCustomer, ICurrentCustomer currentCustomer)
        {
            _savingsCustomer = savingsCustomer;
            _currentCustomer = currentCustomer;
        }

        internal async Task Run()
        {
            Menus.SecondaryCustomerMenu();

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            if (choice == 1)
            {
                _savingsCustomer = await AuthenticateCustomer.Authenticate(_savingsCustomer, ClassLibrary.AccountType.Savings);

                if (_savingsCustomer != null)
                {

                    Console.WriteLine();
                    Console.WriteLine($"Welcome Mr/Mrs. {_savingsCustomer.Name}");
                    Console.ReadLine();

                    int choice2;
                    do
                    {
                        Console.Clear();
                        Menus.TertiaryCustomerMenu();

                        choice2 = Convert.ToInt32(Console.ReadLine());

                        UserChoiceHandler.CustomerChoice(choice2, _savingsCustomer);
                    } while (choice2 != 6);
                }

                else
                {
                    Console.WriteLine("Invalid login pin");
                    Console.WriteLine("Press Enter to exit");
                    Console.ReadLine();
                }
            }

            else if (choice == 2)
            {
                _currentCustomer = await AuthenticateCustomer.Authenticate(_currentCustomer, ClassLibrary.AccountType.Current);

                if (_currentCustomer != null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Welcome {_currentCustomer.Name}");
                    Console.ReadLine();

                    int choice2;
                    do
                    {
                        Console.Clear();
                        Menus.TertiaryCustomerMenu();

                        choice2 = Convert.ToInt32(Console.ReadLine());

                        UserChoiceHandler.CustomerChoice(choice2, _currentCustomer);
                    } while (choice2 != 6);
                }

                else
                {
                    Console.WriteLine("Invalid login pin");
                    Console.WriteLine("Press Enter to exit");
                    Console.ReadLine();
                }
            }

            else
                Console.WriteLine("Invalid selection");

        }
    }
}
