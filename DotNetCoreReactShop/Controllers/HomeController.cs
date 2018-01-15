using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreReactShop.Contexts;
using DotNetCoreReactShop.Models;
using DotNetCoreReactShop.Repository;
using DotNetCoreReactShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreReactShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly DefaultDbContext _context;

        public HomeController(DefaultDbContext passedContext)
        {
            _context = passedContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }

        private List<string> popular = new List<string>(
                new[] { "0000", "0002", "0004" });
        private List<string> bestSellers = new List<string>(
                new[] { "0001", "0003", "0005" });


        [HttpGet]
        [Route("api/pizza/getPopular")]
        public IActionResult GetPopular()
        {
            using (UnitOfWork<Pizza> uow = new UnitOfWork<Pizza>(_context, false))
            {
                var pizzaPopular = uow.Repository.GetAll(
                        s => popular.Contains(s.PizzaNo))
                    .Select(s => new
                    {
                        s.PizzaNo,
                        s.PizzaName,
                        s.CategoryName,
                        s.Image,
                        s.Price
                    }).ToList();

                var pizzaBest = uow.Repository.GetAll(
                        s => bestSellers.Contains(s.PizzaNo))
                    .Select(s => new
                    {
                        s.PizzaNo,
                        s.PizzaName,
                        s.CategoryName,
                        s.Image,
                        s.Price
                    }).ToList();

                pizzaPopular.AddRange(pizzaBest);

                return Json(pizzaPopular);
            }
        }

        [HttpGet]
        [Route("api/pizza/getPizzaDetail/{pizzaNo}")]
        public IActionResult GetPizza(string PizzaNo)
        {
            using (UnitOfWork<Pizza> uow = new UnitOfWork<Pizza>(_context))
            {

                Pizza pizza = uow.Repository.GetEager(s => s.Category, s => s.PizzaNo == PizzaNo);

                PizzaVM pizzaVm = new PizzaVM
                {
                    PizzaNo = pizza.PizzaNo,
                    PizzaName = pizza.PizzaName,

                    CategoryName = pizza.CategoryName,

                    Price = pizza.Price,

                    Image = pizza.Image
                };

                return Json(pizzaVm);
            }
        }

    }
}
