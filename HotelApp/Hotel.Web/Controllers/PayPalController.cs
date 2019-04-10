using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using static Hotel.Web.Controllers.PayPalConfiguraion;

namespace Hotel.Web.Controllers
{
    public class PayPalController : Controller
    {
        private Payment payment;

        private Payment CreatePayment(APIContext apiContext, string redirectUrl, string name, string price)
        {
            var itemList = new ItemList() { items = new List<Item>() };

            itemList.items.Add(new Item()
            {
                name = name,
                currency = "USD",
                price = price,
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
                subtotal = itemList.items[0].price
            };

            var amount = new Amount()
            {
                currency = "USD",
                total = (Convert.ToDouble(details.subtotal) + Convert.ToDouble(details.tax) + Convert.ToDouble(details.shipping)).ToString(),
                details = details
            };

            var trasactionList = new List<Transaction>();
            trasactionList.Add(new Transaction()
            {
                description = "Room booking",
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

        public ActionResult PaymentWithPaypal(string name, string price)
        {
            APIContext apiContext = PayPalConfiguration.GetAPIContext();

            try
            {
                string payerId = Request.Params["PayerId"];
                if (string.IsNullOrEmpty(payerId))
                {
                    var guid = Convert.ToString((new Random()).Next(100000));
                    var createPayment = CreatePayment(apiContext, $"{Request.Url.Scheme}://{Request.Url.Authority}/PayPal/PaymentWithPaypal", name, price);
                    var links = createPayment.links.GetEnumerator();
                    string paypalRedirectUrl = string.Empty;

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
                else
                {
                    var execution = ExecutePayment(apiContext, payerId, Request.Params["paymentId"]);
                    return Redirect("https://google.com");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
                return Redirect("https://google.com");
            }
        }
    }
}