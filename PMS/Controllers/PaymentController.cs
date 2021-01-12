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
                Description = "Payment for invoice " + invoice.id,
                Metadata = new Dictionary<string, string>
                {
                    { "packageID", invoice.Job.packageid.ToString() },
                    { "jobID", invoice.jobid.ToString() },
                    { "invoiceID", invoice.id.ToString() },
                    { "statusPayment", invoice.detail }
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
                int iid = int.Parse(intent.Metadata["invoiceID"]);
                var transaction = new Transaction
                {
                    invoiceid = iid,
                    paymentmethodid = 1,
                    reference = id,
                    total = decimal.Parse((intent.Amount / 100).ToString(".00")),
                    transdate = DateTime.Now
                };
                db.Transactions.Add(transaction);
                db.SaveChanges();

                var invoice = db.Invoices.Find(iid);
                invoice.totalunpaid -= decimal.Parse((intent.Amount / 100).ToString(".00"));
                invoice.status = "Paid";
                db.Entry(invoice).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return View("success", db.Transactions.FirstOrDefault(x => x.invoiceid == iid));
            }
            else
            {
                return View("cancel");
            }
        }
    }
}