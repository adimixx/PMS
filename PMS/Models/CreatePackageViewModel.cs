using PMS.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Models
{
    public class CreatePackageViewModel
    {
        public int id { get; set; }

        [Required]
        [DisplayName("Package Name")]
        public string name { get; set; }

        [Required]
        [DisplayName("Price")]
        public decimal price { get; set; }

        [Required]
        [DisplayName("Deposit Price")]
        public decimal depoprice { get; set; }

        [DisplayName("Package Details")]
        public string details { get; set; }

        public string ImgName { get; set; }

        public IEnumerable<SelectListItem> studio { get; set; }

        public List<PackageImage> images { get; set; }

        [Required]
        [DisplayName("Studio")]
        public int studioid { get; set; }

        public CreatePackageViewModel()
        {
            photogEntities db = new photogEntities();

            studio = db.Studios.ToList().Where(x => x.UserStudios.Any(y => y.userid == UserAuthentication.Identity().id)).ToList().
                Select(x => new SelectListItem { Text = x.name, Value = x.id.ToString()  });
        }
    }
}