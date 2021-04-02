using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi_BudgeManagementSystem.ViewModels
{
    public class IncomeViewModel
    {
        [Key, Required]
        public int incid { get; set; }

        public int inc_amount { get; set; }

        public string inc_cat { get; set; }
        public int uid { get; set; }

    }
}