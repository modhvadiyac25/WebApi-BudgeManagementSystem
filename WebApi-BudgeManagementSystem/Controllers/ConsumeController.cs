using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        BudgetManagerEntities budgetManagerEntities = new BudgetManagerEntities();
        HttpClient hc = new HttpClient();

         
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
        public ActionResult AddIncome(SelectIncomeCategoryViewModel model)
        {

            hc.BaseAddress = new Uri("https://localhost:44320/Api/WebApi/AddIncome");
             

            trasaction  data = budgetManagerEntities.trasactions.Where(x => x.uid.Equals(model.uid)).OrderBy(x => x.tdate).FirstOrDefault();

            string date = System.DateTime.Now.ToString("dd/MM/yyyy");
            string time = System.DateTime.Now.ToString("ddd, dd MMM yyy HH’:’mm’:’ss ‘GMT’");
            string cat = model.inc_cat;

            int amount = 0;
            int expense = 0;

            if (data.Equals(null))
            {
                amount += model.inc_amount;
            }
            {
                amount = data.tot_inc + model.inc_amount;
                expense = data.tot_exp;
            }

            int userid = model.uid;

            trasaction tObj = new trasaction
            {
                tdate = date,
                ttime = time,
                t_cat = cat,
                tot_inc = amount,
                tot_exp = expense,
                uid = userid

            };

            var consume = hc.PostAsJsonAsync("AddIncome", tObj);
            consume.Wait();
            
            var test = consume.Result;

            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("AddIncome", "Consume");
            }
            else
            {
                return RedirectToAction("AddIncome", "Consume");
            }
            return RedirectToAction("AddIncome", "Consume");
        }
    
        [HttpGet]
        public ActionResult AddIncome()
        {
            string uri = "https://localhost:44320/api/webApi/GetIncomeCategory";
            // IEnumerable<IncomeViewModel> list = null;
            var model = new SelectIncomeCategoryViewModel{ };
            hc.BaseAddress = new Uri(uri);

            var cunsume_income = hc.GetAsync("GetIncomeCategory");

            try {cunsume_income.Wait();}
            catch (Exception e){}

            var test = cunsume_income.Result;

            if (test.IsSuccessStatusCode)
            {
                Console.WriteLine("OK !!");
                var display = test.Content.ReadAsAsync<IList<IncomeViewModel>>();
                
                foreach (var category in display.Result)
                {
                    model.categories.Add(category.inc_cat);
                }

                return View(model);
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

        [HttpGet]
        public ActionResult SendData()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendData(user u)
        {
            hc.BaseAddress = new Uri("https://localhost:44320/Api/WebApi/Register");
            var consume = hc.PostAsJsonAsync("Register", u);
            consume.Wait();
            var test = consume.Result;

            





            if (test.IsSuccessStatusCode)
            {
                string date = System.DateTime.Now.ToString("dd/MM/yyyy");
                string time = System.DateTime.Now.ToString("ddd, dd MMM yyy HH’:’mm’:’ss ‘GMT’");

                trasaction t = new trasaction
                {
                    tdate = date,
                    ttime = time,
                    t_cat = "Default",
                    tot_inc = 0,
                    tot_exp = 0,
                    uid = budgetManagerEntities.users.Where(m => m.email.Equals(u.email)).Select(x => x.uid).SingleOrDefault()

                };
                HttpClient hc1 = new HttpClient();
                hc1.BaseAddress = new Uri("https://localhost:44320/Api/WebApi/CreateFirstTransaction");
                var consume_transaction = hc1.PostAsJsonAsync("CreateFirstTransaction", t);
                consume_transaction.Wait();
                var test1 = consume_transaction.Result;

                if (test.IsSuccessStatusCode) {
                    return RedirectToAction("Login");
                }

                    return RedirectToAction("Login");
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }  
        
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return View("Login");
        }

        

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            
            email = email.TrimStart(' ').TrimEnd(' ');
            password = password.TrimStart(' ').TrimEnd(' ');
            string uri = "https://localhost:44320/api/webApi/GetData";
            IEnumerable<UserViewModel> list = null; 
            hc.BaseAddress = new Uri(uri);
   
            var cunsume_income = hc.GetAsync("GetData");

            try {cunsume_income.Wait();}
            catch (Exception e){}


            var test = cunsume_income.Result;

            if (test.IsSuccessStatusCode)
            {                
                Console.WriteLine("OK !!");
                var display = test.Content.ReadAsAsync<IList<UserViewModel>>();
                list = display.Result;

             
                string x_email = "";
                string x_pass = "";
                foreach (var x in list)
                {
                    x_email = x.email.TrimStart(' ').TrimEnd(' ');
                    x_pass = x.password.TrimStart(' ').TrimEnd(' ');

                    if (x_email.Equals(email) && x_pass.Equals(password))
                    {
                        Session["email_id"] = email;
                        Session["uid"] = x.uid;
                        Session["fullname"] = x.fname.ToString() + " " + x.lname;
                        return RedirectToAction("Index", "Home");

                    }
                     
                }
                
            }
            return RedirectToAction("Login", "Consume");


            

            //hc.BaseAddress = new Uri("https://localhost:44320/Api/Login/UserLogin");

            //user u = new user();

            //var consume = hc.GetAsync("UserLogin?email=" + email + "&name" + password);

            //try
            //{
            //    consume.Wait();
            //}

            //catch (Exception e)
            //{
            //    e.StackTrace.ToString();
            //}
            //var test = consume.Result;

            //if (test.IsSuccessStatusCode)
            //{
            //    var display = test.Content.ReadAsAsync<user>();
            //    try
            //    {
            //        display.Wait();
            //        u = display.Result;
            //    }
            //    catch (AggregateException e)
            //    {
            //        Debug.WriteLine(e.ToString());
            //    }
            //}
            //return View(u);
            //return RedirectToAction("Display");

        }
    }
}