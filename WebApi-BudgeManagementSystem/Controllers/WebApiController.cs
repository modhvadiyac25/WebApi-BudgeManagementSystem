using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_BudgeManagementSystem.Models;

namespace WebApi_BudgeManagementSystem.Controllers
{
    public class WebApiController : ApiController
    {
        BudgetManagerEntities budgetManagerEntities = new BudgetManagerEntities();
        
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetData()
        {
            budgetManagerEntities.Configuration.ProxyCreationEnabled = false;
            List<user> list = budgetManagerEntities.users.ToList();
            return Ok(list);
        }            
    }
}
