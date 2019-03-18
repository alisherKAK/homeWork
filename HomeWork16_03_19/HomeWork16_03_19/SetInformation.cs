using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork16_03_19
{
    public static class SetInformation
    {
        public static string SetNickname()
        {
            try
            {
                Console.WriteLine("Full Name: ");

                string nickname = Console.ReadLine().Trim();

                if (nickname == "")
                {
                    throw new ArgumentException("Full Name был введен неверно");
                }

                for (int i = 0; i < nickname.Length; i++)
                {
                    if (!( (nickname[i] >= 'a' && nickname[i] <= 'z') || (nickname[i] >= 'A' && nickname[i] <= 'Z') || 
                        (nickname[i] >= '0' && nickname[i] <= '9') ))
                    {
                        throw new ArgumentException("Full Name был введен неверно");
                    }
                }

                return nickname;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetNickname();
            }
        }
    }
}
