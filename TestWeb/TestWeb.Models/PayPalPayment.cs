using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeb.Models
{
    public class PayPalPayment
    {
        private Payment payment;

        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            var itemList = new ItemList() { items = new List<Item>() };

            itemList.items.Add(new Item()
            {
                name = "Test",
                currency = "AUD",
                price = "100",
                quantity = "1",
                sku = "sku"
            });

            var payer = new Payer() { payment_method = "paypal" };

            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl,
                return_url = redirectUrl
            };

            var details = new Details()
            {
                tax = "1",
                shipping = "2",
                subtotal = "100"
            };

            var amount = new Amount()
            {
                currency = "AUD",
                total = "103",
                details = details
            };

            var trasactionList = new List<Transaction>();
            trasactionList.Add(new Transaction()
            {
                description = "Test trans",
                amount = amount,
                item_list = itemList
            });

            payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = trasactionList,
                redirect_urls = redirUrls
            };

            return payment.Create(apiContext);
        }

        private Payment ExecutePayment(APIContext apiContext, string payerId, string payerSecret)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId,
            };
            payment = new Payment() { id = payment.id };
            return payment.Execute(apiContext, paymentExecution);
        }

        public void PaymentWithPaypal()
        {
            APIContext apiContext = PayPalConfiguration.GetAPIContext();

            try
            {
                var createPayment = CreatePayment(apiContext, "https://google.coms");
                var links = createPayment.links.GetEnumerator();
                string paypalREdirectUrl = string.Empty;

                while (links.MoveNext())
                {
                    Links link = links.Current;
                    if (link.rel.ToLower().Trim().Equals("approval_url"))
                    {
                        paypalREdirectUrl = link.href;
                    }
                }
                Process.Start(paypalREdirectUrl);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
