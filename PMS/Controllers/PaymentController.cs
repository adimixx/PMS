using Google.Cloud.Firestore;
using PMS.Models;
using PMS.Models.Database;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.IO;
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
            try
            {
                var invoice = db.Invoices.Find(id);

                StripeConfiguration.ApiKey = "sk_test_51I0pOnBQ6wryxylDxdJO9JfTueZbork9YIz61xFNChLoDSjFZVDXozdiSsQBcP6raFNlO0u7usJopJ1UtuXfK4ZC00c44ZhQMz";
                var service = new PaymentIntentService();
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)(invoice.total * 100),
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
            catch (Exception e)
            {
                return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
            }
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> statusPayment(string id)
        {
            try
            {
                var service = new PaymentIntentService();
                var intent = service.Get(id);
                if (intent.Status.Contains("succeeded"))
                {
                    int iid = int.Parse(intent.Metadata["invoiceID"]);
                    var transaction = new Models.Database.Transaction
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

                    var job = db.Jobs.Find(invoice.jobid);
                    job.jobstatusid = 1;
                    db.SaveChanges();

                    //Remove Data from Firebase (Quoted Items)
                    var userTrans = db.Transactions.Where(x => x.Invoice.jobid == invoice.jobid);
                    if (userTrans.Count() == 1)
                    {
                        var userInvoice = userTrans.FirstOrDefault().Invoice.Job;
                        var package = userInvoice.Package;
                        var userid = userInvoice.User.id;
                        var chatkey = package.Studio.ChatKeys.FirstOrDefault(x => x.UserID == userid).ChatKeyID;

                        System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"src/json/photogw2-656bf589cae5.json"));
                        FirestoreDb firestore = FirestoreDb.Create("photogw2");

                        var collection = firestore.Collection("Quotation");
                        var query = collection.WhereEqualTo("ChatKey", chatkey);
                        var snapshot = await query.GetSnapshotAsync();

                        var deserializedDataQuoteAll = snapshot.FirstOrDefault().ConvertTo<QuotationModel>();

                        var chat = db.ChatKeys.FirstOrDefault(x => x.ChatKeyID == deserializedDataQuoteAll.ChatKey);
                        var deserializedDataSel = deserializedDataQuoteAll.Packages.FirstOrDefault(x => x.Package.Id == package.id);

                        deserializedDataQuoteAll.Packages.Remove(deserializedDataSel);

                        await collection.Document(snapshot.FirstOrDefault().Id).SetAsync(deserializedDataQuoteAll);
                    }

                    return View("success", db.Transactions.FirstOrDefault(x => x.invoiceid == iid));
                }
                else
                {
                    return View("cancel");
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
            }
        }

        [HttpGet]
        public ActionResult receipt(int id)
        {
            try
            {
                return View("success", db.Transactions.FirstOrDefault(x => x.invoiceid == id));
            }
            catch (Exception e)
            {
                return RedirectToAction("Error500", "Home", new { errormsg = e.Message });
            }
        }
    }
}