using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlRouting.Models;

namespace UrlRouting.Controllers
{
    public class AdminController : Controller
    {
        public ViewResult Index()
        {
            return View("Result", new Result
            {
                Controller = nameof(AdminController),
                Action = nameof(Index)
            });
        }
    }
}
