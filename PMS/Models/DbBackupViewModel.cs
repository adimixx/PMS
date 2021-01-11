using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Models
{
    public class DbBackupViewModel
    {
        public IList<SelectListItem> BackupList { get; set; }

        [Required]
        [Display(Name ="Backup Type")]
        public int SelectedBackupType { get; set; }

        public DbBackupViewModel()
        {
            BackupList = new List<SelectListItem>();

            BackupList.Add(new SelectListItem { Text = "Full Backup", Value = "1" });
            BackupList.Insert(0, new SelectListItem { Text = "Select Backup Type", Disabled = true, Selected = true, Value = "" });
        }
    }
}