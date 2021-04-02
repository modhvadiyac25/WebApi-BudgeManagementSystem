using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_BudgeManagementSystem.Models;

namespace WebApi_BudgeManagementSystem.Controllers
{
    public class LoginController : ApiController
    {
        BudgetManagerEntities budgetManagerEntities = new BudgetManagerEntities();

        [System.Web.Http.HttpGet]
        public IHttpActionResult UserLogin(string email, string password)
        {
             
            budgetManagerEntities.Configuration.ProxyCreationEnabled = false;
            user data = budgetManagerEntities.users.Where(x => x.email.Equals(email) && x.password.Equals(password)).SingleOrDefault();
            return Ok(data);
        }
    }
}
