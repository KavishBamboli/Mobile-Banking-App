using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ClassLibrary.Account;
using ClassLibrary.Customer;

namespace Mobile_Banking_App
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.Register(ctx => new SavingsCustomer(new SavingsAccount()));
            builder.Register(ctx => new CurrentCustomer(new CurrentAccount()));

            return builder.Build();
        }
    }
}
