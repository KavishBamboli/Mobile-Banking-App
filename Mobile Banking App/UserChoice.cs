using ClassLibrary.Customer;
using Mobile_Banking_App.CustomerUseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Banking_App
{
    internal class UserChoice
    {
        public static void CustomerChoice(int choice, ICustomer customer)
        {
            Console.Clear();
            switch (choice)
            {
                case 1:
                    if(WithdrawMoney.Withdraw(customer))
                        Console.WriteLine("Withdrawal successful");
                    else
                        Console.WriteLine("Withdrawal failed!!");
                    Console.ReadLine();
                    break;

                case 2:
                    if(DepositMoney.Deposit(customer))
                        Console.WriteLine("Deposit successful");
                    else
                        Console.WriteLine("Deposit failed as it exceeded amount limit per transaction");
                    Console.ReadLine();
                    break;

                case 3:
                    if (TransferMoney.Transfer(customer))
                        Console.WriteLine("Money transferred successfully");
                    Console.ReadLine();
                    break;

                case 4:
                    if (Convert.ToString(customer.Account.GetType()) == "ClassLibrary.Account.CurrentAccount")
                        Balance.View(ViewCurrentAccountBalance.ViewBalance, customer);
                    else
                        Balance.View(ViewSavingsAccountBalance.ViewBalance, customer);
                    Console.ReadLine();
                    break;

                case 5:
                    ViewStatement.View(customer);
                    Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }
        }
        public static void AdminChoice(int choice)
        {
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
