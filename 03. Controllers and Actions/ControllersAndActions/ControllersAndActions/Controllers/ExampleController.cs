using Microsoft.AspNetCore.Mvc;

namespace ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        public JsonResult Index()
        {
            return Json(new[] { "Pesho", "Ivan", "Maria" });
        }

        //public ContentResult Index()
        //   => Content("[\"Alice\",\"Bob\",\"Joe\"]", "application/json");


        // Using content negotiation
       // public ObjectResult Index() => Ok(new string[] { "Alice", "Bob", "Joe" });

        //public ViewResult Index()
        //{
        //    ViewBag.Message = "Hello";
        //    ViewBag.Date = DateTime.Now;
        //    return View();
        //}

        // public ViewResult Index() => View(DateTime.Now);

        // if we don't cast to object, it's gonna look for View with that name
        public ViewResult Result() => View((object)"Hello World");

        // public RedirectResult Redirect() => Redirect("/Example/Index");
        // public RedirectResult Redirect() => RedirectPermanent("/Example/Index");

        //public RedirectToRouteResult Redirect()
        //      => RedirectToRoute(new { controller = "Example", action = "Index", ID = "MyID" });        public RedirectToActionResult Redirect() => RedirectToAction(nameof(Index));

       // public RedirectToActionResult Redirect()
       //     => RedirectToAction(nameof(HomeController), nameof(HomeController.Index));
    }
}
