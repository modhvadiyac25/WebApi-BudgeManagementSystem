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

 
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetIncomeCategory()
        {
            budgetManagerEntities.Configuration.ProxyCreationEnabled = false;
            List<income> list = budgetManagerEntities.incomes.ToList();
            return Ok(list);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetExpenseCategory()
        {
            budgetManagerEntities.Configuration.ProxyCreationEnabled = false;
            List<expense> list = budgetManagerEntities.expenses.ToList();
            return Ok(list);
        }
 
        [System.Web.Http.HttpPost]
        public IHttpActionResult Register(user u)
        {
            budgetManagerEntities.users.Add(u);
            budgetManagerEntities.SaveChanges();
            return Ok();
 
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult AddIncome(trasaction obj)
        {
            budgetManagerEntities.trasactions.Add(obj);
            budgetManagerEntities.SaveChanges();
            return Ok();
        }
    }
}
