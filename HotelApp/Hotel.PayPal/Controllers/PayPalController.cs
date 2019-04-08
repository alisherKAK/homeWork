using Hotel.PayPal.Models;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Hotel.PayPal.Controllers
{
    public class PayPalController : Controller
    {
        private Payment payment;

        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            var itemList = new ItemList() { items = new List<Item>() };

            itemList.items.Add(new Item()
            {
                name = "Test",
                currency = "USD",
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
                tax = "0",
                shipping = "0",
                subtotal = "100"
            };

            var amount = new Amount()
            {
                currency = "USD",
                total = "100",
                details = details
            };

            var trasactionList = new List<Transaction>();
            trasactionList.Add(new Transaction()
            {
                description = "Test trans",
                amount = amount,
                item_list = itemList,
                invoice_number = Convert.ToString((new Random()).Next(100000))
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

        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId,
            };
            payment = new Payment() { id = paymentId };
            return payment.Execute(apiContext, paymentExecution);
        }

        public ActionResult PaymentWithPaypal()
        {
            APIContext apiContext = PayPalConfiguration.GetAPIContext();
            var guid = Convert.ToString((new Random()).Next(100000));
            var createPayment = CreatePayment(apiContext, $"{Request.Url.Scheme}://{Request.Url.Authority}/PayPal/PaymentExecute?guid={guid}");
            string paypalRedirectUrl = string.Empty;
            var links = createPayment.links.GetEnumerator();

            while (links.MoveNext())
            {
                Links link = links.Current;
                if (link.rel.ToLower().Trim().Equals("approval_url"))
                {
                    paypalRedirectUrl = link.href;
                }
            }

            return Redirect(paypalRedirectUrl);
        }

        public ActionResult PaymentExecute(string guid, string paymentId, string token, string PayerID)
        {
            APIContext apiContext = PayPalConfiguration.GetAPIContext();
            var executePayment = ExecutePayment(apiContext, PayerID, paymentId);

            return Redirect("https://google.com");
        }
    }
}