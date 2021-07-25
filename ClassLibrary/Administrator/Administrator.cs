using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Administrator : IAdministrator
    {
        public string Name { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
    }
}
