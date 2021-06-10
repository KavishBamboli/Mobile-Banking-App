using Autofac;
using ClassLibrary.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Banking_App
{
    internal class UserChoice
    {
        static IContainer container = ContainerConfig.Configure();

        public static void CustomerChoice(int choice, ICustomer customer)
        {
            using (var scope = container.BeginLifetimeScope())
            {
                switch (choice)
                {
                    case 1:
                        //Function to withdraw money
                        break;

                    case 2:
                        //Function to deposit money
                        break;

                    case 3:
                        //Function to transfer money to another account
                        break;

                    case 4:
                        //Function to view balance
                        break;

                    case 5:
                        //Function to view account statement
                        break;

                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }
            }
        }
        public static void AdminChoice(int choice)
        {
            var scope = container.BeginLifetimeScope();

            switch(choice)
            {
                case 1:
                    //Function to create an account
                    break;

                case 2:
                    //Function to modify the account
                    break;

                case 3:
                    //Function to delete the account
                    break;

                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }
        }
    }
}
