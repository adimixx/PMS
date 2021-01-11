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
    public class CreateStudioViewModel : Studio
    {
        public IList<SelectListItem> StateList { get; set; }

        public IList<SelectListItem> CityList { get; set; }

        [DisplayName("State")]
        public string SelectedState { get; set; }

        [DisplayName("City")]
        public string SelectedCity { get; set; }

        public void setCityList(string state)
        {
            var location = new LocationList();
            CityList = location.Cities.FirstOrDefault(x => x.Key.ToLower() == StateList.FirstOrDefault(u => u.Value.ToLower() == state.ToLower()).Value.ToLower()).Value.Select(x => new SelectListItem { Text = x, Value = x }).ToList();
            CityList.Insert(0, new SelectListItem { Text = "Select City", Disabled = true, Selected = true, Value = "" });
        }

        public CreateStudioViewModel()
        {
            var location = new LocationList();

            StateList = location.States.Select(x => new SelectListItem { Text = x, Value = x }).ToList();
            StateList.Insert(0, new SelectListItem { Text = "Select State", Disabled = true, Selected = true, Value = "" });
            CityList = location.Cities.FirstOrDefault(x => x.Key.ToLower() == StateList[1].Value.ToLower()).Value.Select(x => new SelectListItem { Text = x, Value = x }).ToList();
            CityList.Insert(0, new SelectListItem { Text = "Select City", Disabled = true, Selected = true, Value = "" });
        }
    }
}
