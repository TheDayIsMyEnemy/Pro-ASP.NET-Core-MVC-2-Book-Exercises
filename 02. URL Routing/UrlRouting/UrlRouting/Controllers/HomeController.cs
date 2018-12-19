using Microsoft.AspNetCore.Mvc;
using UrlRouting.Models;

namespace UrlRouting.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View("Result", new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(Index)
            });
        }

        public ViewResult CustomVariable(string id)
        {
            Result result = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(CustomVariable)
            };

            //r.Data["Id"] = RouteData.Values["id"];
            result.Data["Id"] = id ?? "<no value>";
            result.Data["catchall"] = RouteData.Values["catchall"];
            result.Data["Url"] = Url.Action("CustomVariable", "Home", new { id = 100 });

            return View("Result", result);
        }
    }
}
