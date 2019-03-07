using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Views.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            //ViewBag.Message = "Hello world";
            //ViewBag.Time = DateTime.Now.ToString("HH:mm:ss");
            //return View("DebugData");

            return View(new string[] { "Apple", "Orange", "Pear" });
        }

        public ViewResult List() => View();
    }
}
