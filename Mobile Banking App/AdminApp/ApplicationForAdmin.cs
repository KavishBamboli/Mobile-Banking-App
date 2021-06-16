using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankingApplication
{
    internal class ApplicationForAdmin
    {
        IAdministrator _admin;

        public ApplicationForAdmin(IAdministrator admin)
        {
            _admin = admin;
        }

        internal async Task Run()
        {
            _admin = await AuthenticateAdmin.Authenticate(_admin);

            if (_admin != null)
            {
                int choice;
                do
                {
                    Console.Clear();
                    Menus.SecondaryAdministratorMenu();
                    choice = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();

                    UserChoiceHandler.AdminChoice(choice);

                } while (choice != 4);
            }

            else
            {
                Console.WriteLine("Wrong username or password");
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
            }
        }
    }
}
