using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Banking_App
{
    class Application
    {

        public void Run()
        {
            Menus.MainMenu();
            Console.WriteLine("Enter your selection");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            if (choice == 1)
            {
                if (AuthenticateUser.AuthenticateCustomer())
                {
                    Menus.SecondaryCustomerMenu();
                    Console.Read();
                }
            }

            else if (choice == 2)
            {
                if (AuthenticateUser.AuthenticateAdmin())
                {
                    Menus.SecondaryAdministratorMenu();
                    Console.Read();
                }
            }

            else
                Console.WriteLine("Invalid Choice");
        }
    }
}
