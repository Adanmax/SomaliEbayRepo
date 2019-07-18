using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SomaliEbay.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace SomaliEbay.Controllers
{
    public class ProductsController : Controller
    {

        private SomaliEbayDbContext _db;

        public ProductsController(SomaliEbayDbContext dbContext)
        {
            _db = dbContext;

        }
        public IActionResult Index()        {

            var products = _db.products.Include(o => o.Orders).ToList();
            return View(products);
        }

        [HttpGet]

        public ActionResult Edit(int Id)
        {
            var product = _db.products.Find(Id);

            if (product == null)
            {
                return RedirectToAction("ErrorPage");
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product,IFormFile productImage)
        {

            if( ModelState.IsValid)
            {
                if (productImage != null)
                {

                    using (var imageBytes = new MemoryStream())
                    {
                        productImage.CopyTo(imageBytes);

                        product.ProductImage = imageBytes.ToArray();
                    }
                }

                _db.products.Update(product);
                    _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]

        public ActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product, IFormFile productImage)
        {

            if (ModelState.IsValid)
            {
                if(productImage != null)
                {

                    using (var imageBytes = new MemoryStream())
                    {
                        productImage.CopyTo(imageBytes);

                        product.ProductImage = imageBytes.ToArray();
                    }
                }

                _db.products.Add(product);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult ErrorPage()
        {

            return View();
        }




       

        public IActionResult Details(int Id)
        {
            var product = _db.products.Include(x => x.Orders).FirstOrDefault(p => p.Id == Id);

            if (product == null)
            {
                return RedirectToAction("ErrorPage");
            }
            return View(product);
        }


        [HttpGet]

        public ActionResult Delete(int Id)
        {
            var product = _db.products.Find(Id);

            if (product == null)
            {
                return RedirectToAction("ErrorPage");
            }
            _db.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        }
}