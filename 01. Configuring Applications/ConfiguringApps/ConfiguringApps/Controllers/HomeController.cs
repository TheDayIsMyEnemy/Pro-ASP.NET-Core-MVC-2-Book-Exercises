﻿using ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService uptime;
        private ILogger<HomeController> logger;

        public HomeController(UptimeService up, ILogger<HomeController> log)
        {
            uptime = up;
            logger = log;
        }

        public ViewResult Index(bool throwException = false)
        {
            logger.LogDebug($"Handled {Request.Path} at uptime {uptime.Uptime}");

            if (throwException)
            {
                throw new NullReferenceException();
            }

            return View(new Dictionary<string, string>
            {
                ["Message"] = "This is the index action",
                ["Uptime"] = $"{uptime.Uptime}ms"
            });
        }

        public ViewResult Error()
        {
            return View(nameof(Index), new Dictionary<string, string>
            {
                ["Message"] = "This is the Error action"
            });
        }
    }
}
