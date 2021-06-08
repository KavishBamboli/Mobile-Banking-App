using Mobile_Banking_App.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Banking_App
{
    class Application
    {
        IMenus _menu;
        public Application(IMenus menu)
        {
            _menu = menu;
        }

        public void Run()
        {
            _menu.MainMenu();
            Console.WriteLine("Enter your selection");
            int choice = Convert.ToInt32(Console.ReadLine());

            //Code to handle the choice
        }
    }
}
