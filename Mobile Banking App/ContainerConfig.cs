using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ClassLibrary.Account;
using ClassLibrary.Customer;
using ClassLibrary;
using System.Reflection;
using MobileBankingApplication.AdminUseClasses;

namespace MobileBankingApplication
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SavingsAccount>().As<ISavingsAccount>();
            builder.RegisterType<CurrentAccount>().As<ICurrentAccount>();
            builder.Register(ctx => new SavingsCustomer(ctx.Resolve<ISavingsAccount>())).As<ISavingsCustomer>();
            builder.Register(ctx => new CurrentCustomer(ctx.Resolve<ICurrentAccount>())).As<ICurrentCustomer>();
            builder.RegisterType<Administrator>().As<IAdministrator>();
            builder.RegisterType<ApplicationForCustomer>().AsSelf();
            builder.RegisterType<ApplicationForAdmin>().AsSelf();

            return builder.Build();
        }
    }
}
