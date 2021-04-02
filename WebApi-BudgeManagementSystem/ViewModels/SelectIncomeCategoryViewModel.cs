using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi_BudgeManagementSystem.ViewModels
{
    public class SelectIncomeCategoryViewModel
    {
        [Key, Required]
        public int incid { get; set; }
        public int uid { get; set; }

        public string inc_cat { get; set; }

        public int inc_amount { get; set; }
        public List<string> categories { get; set; }

        public SelectIncomeCategoryViewModel()
        {
            categories = new List<string>();
        }
    }
}