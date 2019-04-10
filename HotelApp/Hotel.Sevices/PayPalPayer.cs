using Hotel.Services.Abstract;
using System.Diagnostics;

namespace Hotel.Sevices
{
    public class PayPalPayer : IPayer
    {
        public void Pay(string name, string price)
        {
            Process.Start($"http://localhost:4437/PayPal/PaymentWithPaypal?name={name}&price={price}");
        }
    }
}
