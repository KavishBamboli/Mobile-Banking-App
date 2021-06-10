using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Banking_App
{
    internal class ApplicationForAdmin
    {
        IAdministrator _admin;

        public ApplicationForAdmin(IAdministrator admin)
        {
            _admin = admin;
        }

        internal void Run()
        {
            _admin = AuthenticateAdmin.Authenticate(_admin);

            if(_admin != null)
            {
                Menus.SecondaryAdministratorMenu();

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                UserChoice.AdminChoice(choice);
            }

            else
                Console.WriteLine("Invalid selection");
        }
    }
}
