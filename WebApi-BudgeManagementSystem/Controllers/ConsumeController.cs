using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApi_BudgeManagementSystem.Models;
using WebApi_BudgeManagementSystem.ViewModels;

namespace WebApi_BudgeManagementSystem.Controllers
{
    public class ConsumeController : Controller
    {
        HttpClient hc = new HttpClient();

        // GET: Consume
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddExpense()
        {
            string uri = "https://localhost:44320/api/webApi/GetExpenseCategory";
            IEnumerable<ExpenseViewModel> list = null;
            hc.BaseAddress = new Uri(uri);

            var cunsume_expense = hc.GetAsync("GetExpenseCategory");

            try { cunsume_expense.Wait(); }
            catch (Exception e) { }

            var test = cunsume_expense.Result;

            if (test.IsSuccessStatusCode)
            {
                Console.WriteLine("OK !!");
                var display = test.Content.ReadAsAsync<IList<ExpenseViewModel>>();
                list = display.Result;

                return View(list);
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddIncome(IncomeViewModel model)
        {

            return View();
        }

        [HttpGet]
        public ActionResult AddIncome()
        {
            string uri = "https://localhost:44320/api/webApi/GetIncomeCategory";
            IEnumerable<IncomeViewModel> list = null;
            hc.BaseAddress = new Uri(uri);

            var cunsume_income = hc.GetAsync("GetIncomeCategory");

            try {cunsume_income.Wait();}
            catch (Exception e){}

            var test = cunsume_income.Result;

            if (test.IsSuccessStatusCode)
            {
                Console.WriteLine("OK !!");
                var display = test.Content.ReadAsAsync<IList<IncomeViewModel>>();
                list = display.Result;
                
                return View(list);
            }
            return View();

        }


        [HttpGet]
        public ActionResult Display()
        {
            
            string uri = "https://localhost:44320/api/webApi/GetData";
            List<user> list = new List<user>();
            hc.BaseAddress = new Uri(uri);
            var cunsume = hc.GetAsync("GetData");

            try
            {
                cunsume.Wait();
            }
            catch (Exception e)
            {
                e.StackTrace.ToString();  
            }
            
            var test = cunsume.Result;
            
            if (test.IsSuccessStatusCode)
            {
                Console.WriteLine("OK !!");
                var display = test.Content.ReadAsAsync<List<user>>();
                list = display.Result;
                return View(list);
            }
            return View();
        }
    }
}