using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankingApplication.AdminUseClasses
{
    internal static class EmailValidator
    {
        internal static bool Validate(string email)
        {
            if (email.Contains('@'))
            {
                if (email.Substring(email.IndexOf('@')).Contains(".com"))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}
