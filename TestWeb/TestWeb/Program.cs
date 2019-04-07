using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeb.Models;

namespace TestWeb
{
    class Program
    {
        static void Main(string[] args)
        {
            PayPalPayment payment = new PayPalPayment();

            payment.PaymentWithPaypal();

            Console.ReadLine();
        }
    }
}
