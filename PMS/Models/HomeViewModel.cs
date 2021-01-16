using PMS.Models.Database;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Models
{
    public class SearchViewModel
    {
        [Required]
        [DisplayName("keyword")]
        public string keyword { get; set; }

        [DisplayName("sortby")]
        public string sortby { get; set; }

        [DisplayName("minprice")]
        public string minprice { get; set; }

        [DisplayName("maxprice")]
        public string maxprice { get; set; }

        public List<Package> pkg { get; set; }

        public List<Studio> std { get; set; }

        public List<PackageImage> pkgimg { get; set; }
    }


    
}