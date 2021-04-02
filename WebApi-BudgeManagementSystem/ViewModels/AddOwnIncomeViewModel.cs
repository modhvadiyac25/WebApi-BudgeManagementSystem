using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi_BudgeManagementSystem.ViewModels
{
    public class AddOwnIncomeViewModel : SelectIncomeCategoryViewModel
    {
        [Key, Required]
        public int oinc_Id { get; set; }

        public bool flag { get; set; }
        
        public string oinc_name { get; set; }

        public AddOwnIncomeViewModel() : base()
        {

        }

    }
}