using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    [FirestoreData]
    public class PackageQuoteModel
    {
        [FirestoreProperty]
        public long ChatKey { get; set; }
        [FirestoreProperty]
        public PackageDetails Package { get; set; }

        [FirestoreProperty]
        public string OrderStatus { get; set; }

        [FirestoreProperty]
        public List<PackageJsonOrders> Orders { get; set; }

        [FirestoreProperty]
        public List<PackageDate> VenueDates { get; set; }
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
        public string Status { get; set; }
    }
}