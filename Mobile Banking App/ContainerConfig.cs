using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ClassLibrary.Account;
using ClassLibrary.Customer;
using ClassLibrary;
using Mobile_Banking_App.Menu;

namespace Mobile_Banking_App
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.Register(ctx => new SavingsCustomer(new SavingsAccount()));
            builder.Register(ctx => new CurrentCustomer(new CurrentAccount()));
            builder.RegisterType<Administrator>().As<IAdministrator>();
            builder.RegisterType<Menus>().As<IMenus>();
            builder.RegisterType<Application>().AsSelf();
            builder.RegisterType<Transactions>().As<ITransactions>();

            return builder.Build();
        }
    }
}
