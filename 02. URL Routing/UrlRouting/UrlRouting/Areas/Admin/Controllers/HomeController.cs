using Microsoft.AspNetCore.Mvc;
using UrlRouting.Areas.Admin.Models;

namespace UrlRouting.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private Person[] data = new Person[] {
             new Person { Name = "Alice", Age = 17 },
             new Person { Name = "Bob", Age = 23 },
             new Person { Name = "Joe", Age = 21 }
             };

        public ViewResult Index() => View(data);
    }
}
