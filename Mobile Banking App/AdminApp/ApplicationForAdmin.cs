using ClassLibrary;
using ClassLibrary.Customer;
using System;
using System.IO;
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

                Console.WriteLine();
                Console.WriteLine($"Welcome {_admin.Name}");
                Console.ReadLine();

                int choice;

                Stream stream = File.Open(@"D:\Programming Projects\Mobile Banking App\Customers.xlsx", FileMode.Open);
                var savingsCustomers = await LoadCustomerData.Load<ISavingsCustomer>(stream, AccountType.Savings);
                var currentCustomers = await LoadCustomerData.Load<ICurrentCustomer>(stream, AccountType.Current);
                stream.Close();

                do
                {
                    Console.Clear();
                    Menus.SecondaryAdministratorMenu();
                    choice = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();
                    await UserChoiceHandler.AdminChoice(choice, savingsCustomers, currentCustomers);

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
