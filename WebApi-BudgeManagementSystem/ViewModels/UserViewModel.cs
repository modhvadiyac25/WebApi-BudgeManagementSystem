using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_BudgeManagementSystem.ViewModels
{
    public class UserViewModel
    {
        public int uid { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }
        public string mno { get; set; }
        public string password { get; set; }

    }
}