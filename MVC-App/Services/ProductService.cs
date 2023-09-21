using Microsoft.AspNetCore.Mvc;
using MVC_App.Data;
using MVC_App.Models;
using SQLitePCL;

namespace MVC_App.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public void createProduct(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }

        public void deleteProduct(int id)
        {
            Product? product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }

        }

        public Product? GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public void updateProduct(Product product)
        {
            var data = _context.Products.Find(product.Id);
            if (data != null)
            {
                data.Price = product.Price;
                data.Category = product.Category;
                data.Description = product.Description;
                data.Name = product.Name;
                _context.Products.Update(data);
                _context.SaveChanges();
            }
                   }
    }
}
