using PMS.Models.Database;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class PaymentController : Controller
    {
        photogEntities db = new photogEntities();

        [HttpGet]
        public ActionResult CheckoutIndex(int id)
        {
            var invoice = db.Invoices.Find(id);

            StripeConfiguration.ApiKey = "sk_test_51I0pOnBQ6wryxylDxdJO9JfTueZbork9YIz61xFNChLoDSjFZVDXozdiSsQBcP6raFNlO0u7usJopJ1UtuXfK4ZC00c44ZhQMz";
            var service = new PaymentIntentService();
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)invoice.total * 100,
                Currency = "myr",
                PaymentMethodTypes = new List<string>
                {
                    "fpx",
                },
                Description = "Payment for invoice " + invoice.id + " : " + invoice.Job.paymentstatus,
                Metadata = new Dictionary<string, string>
                {
                    { "packageID", invoice.Job.packageid.ToString() },
                    { "jobID", invoice.jobid.ToString() },
                },
            };
            ViewBag.intent = service.Create(options);
            return View(invoice);
        }

        [HttpGet]
        public ActionResult statusPayment(string id)
        {
            var service = new PaymentIntentService();
            var intent = service.Get(id);
            if (intent.Status.Contains("succeeded"))
            {
                return View("success");
            }
            else
            {
                return View("cancel");
            }
        }
    }
}