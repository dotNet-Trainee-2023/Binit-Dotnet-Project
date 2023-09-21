using MVC_App.Models;

namespace MVC_App.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();

        Product? GetProductById(int id);

        void createProduct(Product product);
        void updateProduct(Product product);
        void deleteProduct(int id);

    }
}
