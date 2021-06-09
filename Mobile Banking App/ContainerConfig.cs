using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ClassLibrary.Account;
using ClassLibrary.Customer;
using ClassLibrary;

namespace Mobile_Banking_App
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SavingsAccount>().AsSelf();
            builder.RegisterType<CurrentAccount>().AsSelf();
            builder.Register(ctx => new SavingsCustomer(ctx.Resolve<SavingsAccount>()));
            builder.Register(ctx => new CurrentCustomer(ctx.Resolve<CurrentAccount>()));
            builder.RegisterType<Administrator>().As<IAdministrator>();
            builder.RegisterType<Application>().AsSelf();
            builder.RegisterType<Transactions>().As<ITransactions>();

            return builder.Build();
        }
    }
}
