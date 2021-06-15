using Autofac;
using ClassLibrary.Customer;
using MobileBankingApplication.AdminUseClasses;
using MobileBankingApplication.CustomerUseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankingApplication
{
    internal class UserChoiceHandler
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
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Press 1 to create savings account");
                        Console.WriteLine("Press 2 to create current account");

                        int choice2 = Convert.ToInt32(Console.ReadLine());
                        
                        if(choice2 == 1)
                        {
                            var create = scope.Resolve<CreateSavingsAccount>();
                            create.Create();
                        }

                        else if(choice2 == 2)
                        {
                            var create = scope.Resolve<CreateCurrentAccount>();
                            create.Create();
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter account to modify: ");
                        int accNo = Convert.ToInt32(Console.ReadLine());
                        ModifyAccount.Modify(accNo);

                        break;

                    case 3:
                        Console.WriteLine("Enter account number to delete: ");
                        int acc = Convert.ToInt32(Console.ReadLine());

                        DeleteAccount.Delete(acc);
                        break;

                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }
            }
        }
    }
}
