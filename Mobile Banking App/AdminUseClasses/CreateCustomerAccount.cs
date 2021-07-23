using Autofac;
using ClassLibrary;
using ClassLibrary.Customer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MobileBankingApplication
{
    public class CreateCustomerAccount
    {
        public static async Task CreateAccount<T>(List<T> customers, AccountType type) where T : ICustomer
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var customer = scope.Resolve<T>();

                var prop = customer.GetType().GetProperties();

                for (int i = 0; i < prop.Length - 2; i++)
                {
                    if (prop[i].PropertyType == Type.GetType("System.String"))
                    {
                        Console.WriteLine($"Enter customer {prop[i].Name}");
                        prop[i].SetValue(customer, Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine($"Enter customer {prop[i].Name}");
                        prop[i].SetValue(customer, Convert.ToInt32(Console.ReadLine()));
                    }
                }

                customer.LoginPin = LoginPinGenerator.GeneratePin();
                customer.Account.accNo = AccountNumberGenerator.GenerateAccountNumber(type);

                if (type == AccountType.Savings)
                    customer.Account.MakeDeposit(1500, "Initial deposit");

                await SaveCustomerData.Save<T>(customer, type);
                Console.WriteLine("Account created successfully");
            }
        }
    }
}
