using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork25_04_19.DataAccess
{
    public static class Checker
    {
        public static bool CheckLogin(string login)
        {
            for(int i = 0; i < login.Length; i++)
            {
                if( !(login[i] >= 'a' && login[i] <= 'z') || !(login[i] >= 'A' && login[i] <= 'Z') ||
                    !(login[i] >= '0' && login[i] <= '9') )
                {
                    return false;
                }
            }

            return true;
        }
    }
}
