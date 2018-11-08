﻿using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int productPage = 1) 
            => View(new ProductsListViewModel
            {
              Products = repository.Products
                .Where(c=> category == null || c.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),

              PagingInfo = new PagingInfo
                {
                  CurrentPage = productPage,
                  ItemsPerPage = PageSize,
                  TotalItems = repository.Products.Count()
                },

              CurrentCategory = category

            } );
    }
}
