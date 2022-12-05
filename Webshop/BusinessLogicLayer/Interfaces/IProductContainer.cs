using BusinessLogicLayer.Classes;

namespace BusinessLogicLayer.Interfaces
{
    public interface IProductContainer
    {
        Product GetProductById(int id);
        IEnumerable<Product> GetAllProducts();
        
        bool AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool ArchiveProduct(int id);
        
        IEnumerable<Product> SearchProducts(string? filter = null);
    }
}
