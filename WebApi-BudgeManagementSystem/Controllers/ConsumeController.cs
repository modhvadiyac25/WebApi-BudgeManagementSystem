using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace WebApi_BudgeManagementSystem.Controllers
{
    public class ConsumeController : Controller
    {
        HttpClient hc = new HttpClient();

        // GET: Consume
        public ActionResult Index()
        {
            hc.BaseAddress = new Uri("https://localhost:44320/Api/WebApi");
            return View();
        }
    }
}