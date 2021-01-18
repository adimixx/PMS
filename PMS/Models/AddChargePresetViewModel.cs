using PMS.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class AddChargePresetViewModel : Charge
    {
        [MaxLength(50, ErrorMessage = Backbone.ErrorMaxLength)]
        [Required]
        public new string Name { get; set; }

        [MaxLength(50, ErrorMessage = Backbone.ErrorMaxLength)]
        public new string Description { get; set; }

        [Range(0.0, 9999.99,ErrorMessage = Backbone.ErrorMaxRange)]
        public new Nullable<decimal> Price { get; set; }

        [MaxLength(10, ErrorMessage = Backbone.ErrorMaxLength)]
        public new  string Unit { get; set; }
    }
}