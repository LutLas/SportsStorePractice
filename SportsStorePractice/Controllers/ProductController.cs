using Microsoft.AspNetCore.Mvc;
using SportsStorePractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStorePractice.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult List() => View(repository.Products);
    }
}
