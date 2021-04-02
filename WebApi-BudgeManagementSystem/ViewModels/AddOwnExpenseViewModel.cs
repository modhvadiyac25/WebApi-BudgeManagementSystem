using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi_BudgeManagementSystem.ViewModels
{
    public class AddOwnExpenseViewModel : SelectExpenseCategoryViewModel
    {
        [Key, Required]
        public int oexp_Id { get; set; }

        public bool flag { get; set; }
        
        public string oexp_name { get; set; }

        public AddOwnExpenseViewModel() : base()
        {

        }

    }
}