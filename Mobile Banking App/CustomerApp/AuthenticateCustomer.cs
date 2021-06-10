using Autofac;
using ClassLibrary.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Banking_App
{
    internal static class AuthenticateCustomer
    {
        internal static ICustomer Authenticate(ICustomer customer)
        {
            return customer;
        }
    }
}
