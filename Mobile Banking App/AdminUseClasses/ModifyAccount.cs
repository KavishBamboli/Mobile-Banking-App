using ClassLibrary;
using ClassLibrary.Customer;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankingApplication.AdminUseClasses
{
    internal static class ModifyAccount
    {
        internal static void Modify<T>(int accNo, AccountType type) where T : ICustomer
        {
            int row;
            var customer = RetrieveCustomer.Retrieve<T>(accNo, type, out row);

            FileInfo file = new FileInfo(@"D:\Programming Projects\Mobile Banking App\Customers.xlsx");

            if (customer != null && row!=0)
            {
                using (var package = new ExcelPackage(file))
                {
                    ExcelWorksheet ws;
                    if (type == AccountType.Savings)
                        ws = package.Workbook.Worksheets[0];
                    else
                        ws = package.Workbook.Worksheets[1];

                    var prop = customer.GetType().GetProperties();

                    for (int i = 0; i < prop.Length - 1; i++)
                    {
                        Console.WriteLine($"{i + 1}. Modify {prop[i].Name}");
                    }
                    Console.WriteLine("Enter your selection");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter new name: ");
                            ws.Cells[row, 1].Value = Console.ReadLine();

                            break;

                        case 2:
                            Console.WriteLine($"Enter new {prop[1].Name}");
                            if (prop[1].PropertyType == Type.GetType("System.String"))
                                ws.Cells[row, 2].Value = Console.ReadLine();
                            else
                                ws.Cells[row, 2].Value = int.Parse(Console.ReadLine());

                            break;

                        case 3:
                            Console.WriteLine("Enter new email: ");
                            string email;
                            do
                            {
                                email = Console.ReadLine();
                            } while (EmailValidator.Validate(email));

                            ws.Cells[row, 3].Value = email;

                            break;

                        case 4:
                            int pin = LoginPinGenerator.GeneratePin();
                            Console.WriteLine($"New login pin is {pin}");

                            ws.Cells[row, 4].Value = pin;

                            break;

                        default:
                            Console.WriteLine("Invalid selection");
                            break;
                    }
                    package.Save();
                    Console.WriteLine("Changes made successfully");
                }
            }


            else
                Console.WriteLine("Account not found");
        }
    }
}
