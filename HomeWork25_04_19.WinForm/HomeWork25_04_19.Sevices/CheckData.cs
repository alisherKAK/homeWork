﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork25_04_19.Sevices
{
    public static  class CheckData
    {
        public static bool IsLoginCorrect(string login)
        {
            if (login != string.Empty)
            {
                for (int i = 0; i < login.Length; i++)
                {
                    if (!(login[i] >= 'a' && login[i] >= 'z') && !(login[i] >= 'A' && login[i] >= 'Z') && !(login[i] >= '0' && login[i] >= '9')
                        && login[i] == '_')
                    {
                        return false;
                    }
                }

                return true;
            }
            return false;
        }

        public static bool IsPasswordCorrect(string password)
        {
            if (password.Length >= Constants.MINIMAL_PASSWORD_LENGTH)
            {
                for (int i = 0; i < password.Length; i++)
                {
                    if(!(password[i] >= 'a' && password[i] >= 'z') && !(password[i] >= 'A' && password[i] >= 'Z') && 
                        !(password[i] >= '0' && password[i] >= '9'))
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public static bool IsPhoneNumberCorrect(string phoneNumber)
        {
            if(phoneNumber[Constants.FIRST_ELEMENT] == '+' && phoneNumber.Length == Constants.PHONE_NUMEBR_LENGTH)
            {
                for(int i = 1; i < phoneNumber.Length; i++)
                {
                    if( !(phoneNumber[i] >= '0' && phoneNumber[i] <= '9') )
                    {
                        return false;
                    }
                }
                return true;
            }

            return false;
        }

        public static bool IsIdCorrect(string id)
        {
            int intId;

            if(int.TryParse(id, out intId))
            {
                return true;
            }

            throw new ArgumentException("Id был введен неверно");
        }

        public static bool IsAdminCorrect(string isAdmin)
        {
            bool IsAdmin;

            if(bool.TryParse(isAdmin, out IsAdmin))
            {
                return true;
            }

            throw new ArgumentException("Введите True или False");
        }
    }
}
