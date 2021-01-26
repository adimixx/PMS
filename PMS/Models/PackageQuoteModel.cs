using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    [FirestoreData]
    public class QuotationModel
    {
        [FirestoreProperty]
        public long ChatKey { get; set; }
        [FirestoreProperty]
        public List<PackageQuoteModel> Packages { get; set; }
    }

    [FirestoreData]
    public class PackageQuoteModel
    {

        [FirestoreProperty]
        public PackageDetails Package { get; set; }

        [FirestoreProperty]
        public string OrderStatus { get; set; }

        [FirestoreProperty]
        public string JobLink { get; set; }

        [FirestoreProperty]
        public string JobID { get; set; }

        [FirestoreProperty]
        public string HasDeposit { get; set; }

        [FirestoreProperty]
        public string StudioUrl { get; set; }

        [FirestoreProperty]
        public List<PackageJsonOrders> Charges { get; set; }

        [FirestoreProperty]
        public List<PackageDate> Venues { get; set; }
    }

    [FirestoreData]
    public partial class PackageDate
    {
        [FirestoreProperty]
        public string Location { get; set; }
        [FirestoreProperty]
        public DateTime Date { get; set; }
    }

    [FirestoreData]
    public partial class PackageJsonOrders
    {
        [FirestoreProperty]
        public string Remarks { get; set; }
        [FirestoreProperty]
        public float PricePerUnit { get; set; }
        [FirestoreProperty]
        public string Unit { get; set; }
        [FirestoreProperty]
        public long Quantity { get; set; }
        [FirestoreProperty]
        public float TotalPrice { get; set; }
    }

    [FirestoreData]
    public partial class PackageDetails
    {
        [FirestoreProperty]
        public long Id { get; set; }
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public float Price { get; set; }

        [FirestoreProperty]
        public float DepositPrice { get; set; }

        [FirestoreProperty]
        public string Status { get; set; }
    }
}