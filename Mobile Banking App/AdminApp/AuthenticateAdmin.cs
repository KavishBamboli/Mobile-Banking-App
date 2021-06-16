using ClassLibrary;
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
            string path = @"D:\Programming Projects\Mobile Banking App\AdminDetails\admins.csv";
            var admins = await Task.Run(() => LoadFromFile.LoadData<Administrator>(path));

            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();

            foreach(Administrator administrator in admins)
            {
                if (administrator.userName == username && administrator.password == password)
                    return (IAdministrator)administrator;
            }
            return null;
        }
    }
}
