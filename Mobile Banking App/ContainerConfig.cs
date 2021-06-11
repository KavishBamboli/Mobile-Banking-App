﻿using System;
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

            builder.RegisterType<SavingsAccount>().As<IAccount>();
            builder.RegisterType<CurrentAccount>().As<ICurrentAccount>();
            builder.Register(ctx => new SavingsCustomer(ctx.Resolve<IAccount>())).As<ISavingsCustomer>();
            builder.Register(ctx => new CurrentCustomer(ctx.Resolve<ICurrentAccount>())).As<ICurrentCustomer>();
            builder.RegisterType<Administrator>().As<IAdministrator>();
            builder.RegisterType<Transactions>().As<ITransactions>();
            builder.RegisterType<ApplicationForCustomer>().AsSelf();
            builder.RegisterType<ApplicationForAdmin>().AsSelf();

            return builder.Build();
        }
    }
}
