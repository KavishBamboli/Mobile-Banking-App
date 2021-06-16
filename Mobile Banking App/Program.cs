using Autofac;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankingApplication
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                Menus.MainMenu();

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if(choice==1)
                {
                    var app = scope.Resolve<ApplicationForCustomer>();
                    app.Run();
                }

                else if(choice==2)
                {
                    var app = scope.Resolve<ApplicationForAdmin>();
                    await app.Run();
                }
                
            }
        }
    }
}
