﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi_BudgeManagementSystem.ViewModels
{
    public class ExpenseViewModel
    {
        [Key, Required]
        public int expid { get; set; }

        public int exp_amount { get; set; }

        public string exp_cat { get; set; }
    }
}