using ClassLibrary.Customer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using OfficeOpenXml;
using ClassLibrary;
using System.Linq;

namespace MobileBankingApplication
{
    public class AuthenticateCustomer
    {
        public static async Task<T> Authenticate<T>(T customer, AccountType type) where T : ICustomer
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            Stream stream = File.Open(@"D:\Programming Projects\Mobile Banking App\Customers.xlsx", FileMode.Open);
            var customers = await LoadCustomerData.Load<T>(stream, type);

            stream.Close();

            customers = customers.OrderBy(x => x.LoginPin).ToList();

            Console.WriteLine("Enter Login Pin: ");
            int pin = Convert.ToInt32(Console.ReadLine());

            customer = Search<T>(customers, 0, customers.Count - 1, pin);

            if (customer != null)
                return customer;
            else
                return default(T);
        }

        private static T Search<T>(List<T> customers, int low, int high, int pin) where T : ICustomer
        {
            if (high >= low)
            {
                int mid = low + (high - low) / 2;

                if (customers[mid].LoginPin == pin)
                    return customers[mid];
                else if (pin < customers[mid].LoginPin)
                    return Search<T>(customers, low, mid - 1, pin);
                else
                    return Search<T>(customers, mid + 1, high, pin);
            }

            return default(T);
        }
    }
}
