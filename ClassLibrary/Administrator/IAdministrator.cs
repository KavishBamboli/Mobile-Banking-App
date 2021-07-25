using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IAdministrator
    {
        string Name { get; set; }
        string userName { get; set; }
        string password { get; set; }
    }
}
