using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository repository;
        private ProductTotalizer totalizer;

        public HomeController(IRepository repo, ProductTotalizer total)
        {
            repository = repo;
            totalizer = total;
        }

        //public ViewResult Index()
        //{
        //    ViewBag.HomeController = repository.ToString();
        //    ViewBag.Totalizer = totalizer.Repository.ToString();
        //    return View(repository.Products);
        //}
            
        // ACTION INJECTION
        public ViewResult Index([FromServices]ProductTotalizer totalizer)
        {
            IRepository repository = 
                (IRepository)HttpContext.RequestServices.GetService(typeof(IRepository)); // service locator pattern

            ViewBag.Repository = repository.ToString();
            ViewBag.RepositoryDirectlyFromServices = this.repository.ToString();
            ViewBag.Totalizer = totalizer.Repository.ToString();
            ViewBag.TotalizerFromActionInjection = this.totalizer.Repository.ToString();
            return View(repository.Products);
        }
        
    }
}
