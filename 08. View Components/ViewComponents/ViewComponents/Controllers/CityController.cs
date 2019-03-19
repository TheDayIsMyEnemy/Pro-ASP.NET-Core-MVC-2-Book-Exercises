using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;
using ViewComponents.Models;

namespace ViewComponents.Controllers
{
    [ViewComponent(Name = "ComboComponent")]
    public class CityController : Controller
    {
        private ICityRepository repo;

        public CityController(ICityRepository repo)
        {
            this.repo = repo;
        }

        public ViewResult Create() => View();

        [HttpPost]
        public IActionResult Create(City newCity)
        {
            repo.AddCity(newCity);
            return RedirectToAction("Index", "Home");
        }

        public IViewComponentResult Invoke()
        {
            return new ViewViewComponentResult()
            {
                ViewData = new ViewDataDictionary<IEnumerable<City>>(ViewData, repo.Cities)
            };
        }
    }
}
