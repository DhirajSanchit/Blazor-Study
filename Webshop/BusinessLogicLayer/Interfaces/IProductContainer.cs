using BusinessLogicLayer.Classes;
using InterfaceLayer.Dtos;

namespace BusinessLogicLayer.Interfaces
{
    public interface IProductContainer
    {
        Product GetProductById(int id);
        IEnumerable<Product> GetAllProducts(string filter = null);        
    }
}
