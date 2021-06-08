using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public static class LoginPinGenerator
    {
        public static int GeneratePin()
        {
            Random rand = new Random();
            return rand.Next(1000, 9999);
        }
    }
}
