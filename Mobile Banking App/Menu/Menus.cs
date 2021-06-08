using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Banking_App.Menu
{
    class Menus : IMenus
    {
        public void MainMenu()
        {
            Console.WriteLine("Press 1 to login as Customer");
            Console.WriteLine("Press 2 to login as Administrator");
        }

        public void SecondaryAdministratorMenu()
        {
            Console.WriteLine("1. Create a customer account");
            Console.WriteLine("2. Modify a customer account");
            Console.WriteLine("3. Delete a customer account");
        }

        public void SecondaryCustomerMenu()
        {
            Console.WriteLine("1. Withdraw money from your account");
            Console.WriteLine("2. Deposit money into your account");
            Console.WriteLine("3. Transfer money into other accounts");
            Console.WriteLine("4. View balance in your account");
            Console.WriteLine("5. View mini account statement");
        }
    }
}
