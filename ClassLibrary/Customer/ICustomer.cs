using ClassLibrary.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Customer
{
    public interface ICustomer
    {
        string Name { get; set; }
        string Email { get; set; }
        int LoginPin { get; set; }
        IAccount Account { get; set; }
    }
}
