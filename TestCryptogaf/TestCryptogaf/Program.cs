using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace TestCryptogaf
{
    class Program
    {
        static void Main(string[] args)
        {
            string hash = "f0xle@rn";
            string a = "Hello World bcbif cufhic cnuficnjf";
            string encr = Encrypt(a, ref hash);
            string dec = Decrypt(encr, hash);

            string password = encr + hash;

            var s = password.Split('=');
        }

        private static string Encrypt(string text, ref string hash)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(text);
            using(MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                hash = text.GetHashCode().ToString();
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider()
                {  Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7})
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(result, 0, result.Length);
                }
            }
        }
        private static string Decrypt(string encrypt, string hash)
        {
            byte[] data = Convert.FromBase64String(encrypt);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider()
                { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(result);
                }
            }
        }
    }
}
