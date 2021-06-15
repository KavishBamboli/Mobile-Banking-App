using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankingApplication
{
    internal static class Menus
    {
        internal static void MainMenu()
        {
            Console.WriteLine("Press 1 to login as Customer");
            Console.WriteLine("Press 2 to login as Administrator");
            Console.WriteLine("Enter your selection");
        }

        internal static void SecondaryAdministratorMenu()
        {
            Console.WriteLine("1. Create a customer account");
            Console.WriteLine("2. Modify a customer account");
            Console.WriteLine("3. Delete a customer account");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your selection");
        }

        internal static void SecondaryCustomerMenu()
        {
            Console.WriteLine("Press 1 if you have a savings account");
            Console.WriteLine("Press 2 if you have a current account");
        }

        internal static void TertiaryCustomerMenu()
        {
            Console.WriteLine("1. Withdraw money from your account");
            Console.WriteLine("2. Deposit money into your account");
            Console.WriteLine("3. Transfer money into other accounts");
            Console.WriteLine("4. View balance in your account");
            Console.WriteLine("5. View mini account statement");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Enter your selection");
        }
    }
}
