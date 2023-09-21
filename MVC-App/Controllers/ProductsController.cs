using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_App.Data;
using MVC_App.Models;
using MVC_App.Services;

namespace MVC_App.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: Products
        public IActionResult Index()
        {
            return View(_productService.GetProducts());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetProductById((int)id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Description,Category")] Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _productService.createProduct(product);
            return RedirectToAction("Index", "Products");
        }

        public IActionResult Edit(int id)
        {
            var product = _productService.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Name,Price,Description,Category")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            _productService.updateProduct(product);

           return RedirectToAction("Index", "Products");
        }
    

        public IActionResult Delete(int id)
    {
            var product = _productService.GetProductById(id);
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public  IActionResult DeleteConfirmed(int id)
        {
            _productService.deleteProduct(id);
            return RedirectToAction("Index", "Products");
        }
    }
}
