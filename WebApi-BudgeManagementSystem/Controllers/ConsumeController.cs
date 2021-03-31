using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApi_BudgeManagementSystem.Models;

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

        public ActionResult Display()
        {
            List<user> list = new List<user>();
            hc.BaseAddress = new Uri("https://localhost:44320/Api/WebApi/GetData");
            var consume = hc.GetAsync("GetData");
            try
            {
                consume.Wait();
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e);
            }

            var test = consume.Result;

            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<user>>();
                list = display.Result;
            }

            return View(list);
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
                return RedirectToAction("Display");
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpGet]

        public ActionResult Login(string email, string password)
        {
            hc.BaseAddress = new Uri("https://localhost:44320/Api/Login/UserLogin");

            user u = new user();
            
            var consume = hc.GetAsync("UserLogin?email="+email+"&name"+password);
            consume.Wait();
            var test = consume.Result;

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

            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Display");
            }
           else
            {
                return HttpNotFound();
            }
        }
           
    }
}