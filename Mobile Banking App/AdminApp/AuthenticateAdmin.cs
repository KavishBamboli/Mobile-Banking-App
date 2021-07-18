using ClassLibrary;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankingApplication
{
    internal static class AuthenticateAdmin
    {
        internal async static Task<IAdministrator> Authenticate(IAdministrator admin)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            Stream stream = File.Open(@"D:\Programming Projects\Mobile Banking App\Admins.xlsx", FileMode.Open);

            var admins = await LoadAdminData.Load(stream);

            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();

            foreach (Administrator administrator in admins)
            {
                if (administrator.userName == username && administrator.password == password)
                    return (IAdministrator)administrator;
            }
            return null;
        }
    }
}
