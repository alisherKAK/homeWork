using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NamespacesLesson15_01_19
{
    public class User
    {
        private string _login;
        private string _password;
        private string _email;
        private string _telephoneNumber;
        private bool _isRegistred;

        public void Registration()
        {
            string repeatPassword;
            bool isLoginCorrect = false, passwordFirstCondition = false, passwordSecondCondition = false, passwordThirdCondition = false, passwordFourthCondition = false,
                isRepeatPasswordCorrect = false, isEmailCorrect = false, isPasswordCorrect = false, isCodeCorrect = false;

            while (true)
            {
                isLoginCorrect = false; isPasswordCorrect = false; isRepeatPasswordCorrect = false; isEmailCorrect = false; isCodeCorrect = false;
                passwordFirstCondition = false; passwordSecondCondition = false; passwordThirdCondition = false; passwordFourthCondition = false;

                Console.Write("Login: ");
                _login = Console.ReadLine();
                _login.Trim();

                Console.Write("Password: ");
                _password = "";
                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Enter)
                    {
                        Console.Write("*");
                        _password += key.KeyChar;
                    }
                } while (key.Key != ConsoleKey.Enter);
                _password.Trim();
                Console.WriteLine();

                Console.Write("Repeat password: ");
                repeatPassword = Console.ReadLine();
                repeatPassword.Trim();

                Console.Write("Email: ");
                _email = Console.ReadLine();
                _email.Trim();

                Console.Write("Telephone number (+7-xxx-xxx-xx-xx): ");
                _telephoneNumber = Console.ReadLine();
                _telephoneNumber.Trim();

                if (!_login.Equals(' '))
                {
                    isLoginCorrect = true;
                }

                for (int i = 0; i < _password.Length; i++)
                {
                    if (_password[i] >= 'A' && _password[i] <= 'Z')
                    {
                        passwordFirstCondition = true;
                    }
                    else if (_password[i] >= 'a' && _password[i] <= 'z')
                    {
                        passwordSecondCondition = true;
                    }
                    else if (_password[i] >= (char)ConsoleKey.D0 && _password[i] <= (char)ConsoleKey.D9)
                    {
                        passwordThirdCondition = true;
                    }
                    else if (_password[i] == '$')
                    {
                        passwordFourthCondition = true;
                    }
                    else
                    {
                        passwordFirstCondition = false;
                        break;
                    }
                }
                isPasswordCorrect = passwordFirstCondition && passwordSecondCondition && passwordThirdCondition && passwordFourthCondition;

                if (_password == repeatPassword)
                {
                    isRepeatPasswordCorrect = true;
                }

                if (_email.Split('@')[Constants.SECOND_PART].Split('.').Length == Constants.EMAIL_CHECK_NUMEBR)
                {
                    isEmailCorrect = true;
                }

                if (isLoginCorrect && isPasswordCorrect && isRepeatPasswordCorrect && isEmailCorrect)
                {
                    int secretNumbers = Constants.NULL;
                    Random randNumber = new Random();
                    for (int i = 0; i < Constants.SECRET_NUMBERS_COUNT; i++)
                    {
                        secretNumbers *= Constants.ADD_ONE_ZERO;
                        secretNumbers += randNumber.Next(Constants.NULL, Constants.NINE);
                    }

                    SMS.GetSms(_telephoneNumber, secretNumbers.ToString());
                    Console.Write("Secret code: ");

                    if (Console.ReadLine() == secretNumbers.ToString())
                    {
                        _isRegistred = true;
                        Console.WriteLine($"{_login} Registred!");
                        break;
                    }
                }
                else
                {
                    if(isLoginCorrect == false)
                    {
                        Console.WriteLine("Incorrect login!");
                    }
                    else if(isPasswordCorrect == false)
                    {
                        Console.WriteLine("Incorrect password!");
                    }
                    else if(isRepeatPasswordCorrect == false)
                    {
                        Console.WriteLine("Repeat password not equal password!");
                    }
                    else if(isEmailCorrect == false)
                    {
                        Console.WriteLine("Incorrect email!");
                    }
                    else if(isCodeCorrect == false)
                    {
                        Console.WriteLine("Wrong code!");
                    }
                }
            }
        }
    }
}
