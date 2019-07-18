using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SomaliEbay.Models;

namespace SomaliEbay.Controllers
{
    public class HomeController : Controller
    {

        private SomaliEbayDbContext _db;

        public HomeController(SomaliEbayDbContext dbContext)
        {
            _db = dbContext;

        }
        public IActionResult Index(string Search)
        {

            var products = _db.products.ToList();

            if (!string.IsNullOrEmpty(Search))
            {

             products =   products.Where(x => x.ProducName.ToLower().Contains(Search.ToLower()) ||
                x.Price.ToString().ToLower().Contains(Search.ToLower())).ToList();
            }

            return View(products);
                    
             
                    
                    

            
            
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
