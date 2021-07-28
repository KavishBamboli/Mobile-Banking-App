using ClassLibrary;
using ClassLibrary.Customer;
using MobileBankingApplication.AdminUseClasses;
using MobileBankingApplication.CustomerUseClasses;
using System;
using System.Collections.Generic;
using System.IO;
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
                    Console.WriteLine("Enter beneficiary account number: ");
                    int accNo = Convert.ToInt32(Console.ReadLine());

                    int row;
                    if(accNo.ToString().Substring(0, 4) == "1001" && accNo.ToString().Length == 9)
                    {
                        var beneficiaryCustomer = RetrieveCustomer.Retrieve<ISavingsCustomer>(accNo, AccountType.Savings, out row);
                        if (TransferMoney.Transfer(customer, beneficiaryCustomer))
                            Console.WriteLine("Money transferred successfully");
                    }

                    else if(accNo.ToString().Substring(0, 4) == "9001" && accNo.ToString().Length == 9)
                    {
                        var beneficiaryCustomer = RetrieveCustomer.Retrieve<ICurrentCustomer>(accNo, AccountType.Current, out row);
                        if (TransferMoney.Transfer(customer, beneficiaryCustomer))
                            Console.WriteLine("Money transferred successfully");
                    }

                    else
                        Console.WriteLine("Invalid account number");

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

                case 6:
                    Console.WriteLine("You have successfully logged out");
                    Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }
        }
        public static async Task AdminChoice(int choice, List<ISavingsCustomer> savingsCustomers, List<ICurrentCustomer> currentCustomers)
        {
            Console.Clear();

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Press 1 to create savings account");
                    Console.WriteLine("Press 2 to create current account");

                    int choice2 = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    if (choice2 == 1)
                        await CreateCustomerAccount.CreateAccount(savingsCustomers, AccountType.Savings);

                    else if (choice2 == 2)
                        await CreateCustomerAccount.CreateAccount(currentCustomers, AccountType.Current);

                    else
                        Console.WriteLine("Invalid choice");

                    Console.ReadLine();
                    break;

                case 2:
                    Console.WriteLine("Enter account number to modify: ");
                    int accNo = Convert.ToInt32(Console.ReadLine());

                    if (accNo.ToString().Substring(0, 4) == "1001")
                        ModifyAccount.Modify<ISavingsCustomer>(accNo, AccountType.Savings);

                    else if (accNo.ToString().Substring(0, 4) == "9001")
                        ModifyAccount.Modify<ICurrentCustomer>(accNo, AccountType.Current);

                    else
                        Console.WriteLine("Invalid account number");

                    Console.ReadLine();

                    break;

                case 3:
                    Console.WriteLine("Enter account number to delete: ");
                    int acc = Convert.ToInt32(Console.ReadLine());

                    if (acc.ToString().Substring(0, 4) == "1001")
                        DeleteAccount.Delete<ISavingsCustomer>(acc, AccountType.Savings);

                    else if (acc.ToString().Substring(0, 4) == "9001")
                        DeleteAccount.Delete<ICurrentCustomer>(acc, AccountType.Current);

                    else
                        Console.WriteLine("Invalid account number");

                    Console.ReadLine();
                    break;

                case 4:
                    Console.WriteLine("You have successfully logged out");
                    Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }
        }
    }
}
