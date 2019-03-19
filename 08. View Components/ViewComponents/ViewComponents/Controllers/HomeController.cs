using Microsoft.AspNetCore.Mvc;
using ViewComponents.Models;

namespace ViewComponents.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository repository;

        public HomeController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Products);

        public ViewResult Create() => View();

        [HttpPost]
        public IActionResult Create(Product product)
        {
            repository.AddProduct(product);
            return RedirectToAction(nameof(HomeController.Index));
        }
    }
}
