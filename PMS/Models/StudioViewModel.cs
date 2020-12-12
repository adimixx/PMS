using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Models
{
    public class CreateStudioViewModel
    {
        [Required]
        [DisplayName("Studio Name")]
        public string Name { get; set; }

        public IEnumerable<SelectListItem> StateList { get; set; }

        public IEnumerable<SelectListItem> CityList { get; set; }

        [Required]
        [DisplayName("State")]
        public string SelectedState { get; set; }

        [Required]
        [DisplayName("City")]
        public string SelectedCity { get; set; }

        public CreateStudioViewModel()
        {
            var location = new LocationList();

            StateList = location.States.Select(x => new SelectListItem { Text = x, Value = x });
            CityList = location.Cities.FirstOrDefault(x => x.Key.ToLower() == StateList.FirstOrDefault().Value.ToLower()).Value.Select(x => new SelectListItem { Text = x, Value = x });
        }

    }
}