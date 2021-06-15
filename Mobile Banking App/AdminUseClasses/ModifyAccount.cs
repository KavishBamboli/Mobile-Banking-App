using ClassLibrary;
using ClassLibrary.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankingApplication.AdminUseClasses
{
    internal static class ModifyAccount
    {
        internal static void Modify(int accNo)
        {
            ICustomer customer = null;//Function to get the customer from the file

            if(customer!=null)
            {
                Console.WriteLine("\n1. Modify Name\n3.Change login pin\n3.Modify email\n");
                Console.WriteLine("Enter your selection");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter new name: ");
                        customer.Name = Console.ReadLine();

                        break;

                    case 2:
                        customer.LoginPin = LoginPinGenerator.GeneratePin();
                        Console.WriteLine($"New login pin is {customer.LoginPin}");

                        break;

                    case 3:
                        Console.WriteLine("Enter new email: ");
                        do
                        {
                            customer.Email = Console.ReadLine();
                        } while (EmailValidator.Validate(customer.Email));

                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }
            }

            //Function to write changes back to file
            else
                Console.WriteLine("Account not found");
        }
    }
}
