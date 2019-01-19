using Microsoft.AspNetCore.Mvc;

namespace ControllersAndActions.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => View("SimpleForm");

        // it uses HttpRequest context object to extract values from the request
        //public ViewResult ReceiveForm()
        //{
        //    var name = Request.Form["name"];
        //    var city = Request.Form["city"];
        //    return View("Result", $"{name} lives in {city}");
        //}

        //MVC will provide values for action method parameters by checking context objects automatically
        //, including Request.QueryString, Request.Form, and RouteData.Values.
        //public ViewResult ReceiveForm(string name, string city)
        //{
        //    return View("Result", $"{name} lives in {city}");
        //}

        //public void ReceiveForm(string name, string city)
        //    {
        //        Response.StatusCode = 200;
        //        Response.ContentType = "text/html";
        //        byte[] content = Encoding.ASCII
        //        .GetBytes($"<html><body>{name} lives in {city}</body>");
        //        Response.Body.WriteAsync(content, 0, content.Length);
        //    }

        //public IActionResult ReceiveForm(string name, string city)
        //    => new CustomHtmlResult
        //    {
        //     Content = $"{name} lives in {city}"
        //    };

        public RedirectToActionResult ReceiveForm(string name, string city)
        {
            // TempData relies on the Session Middleware!
            // Temp data values are marked for deletion when they are read and removed
            // from the data store when the request has been processed.

            TempData["name"] = name;
            TempData["city"] = city;

            return RedirectToAction(nameof(Data));
        }


        public ViewResult Data()
        {
            string name = TempData["name"] as string;
            string city = TempData["city"] as string;

            return View("Result", $"{name} lives in {city}");
        }
        
    }
}
