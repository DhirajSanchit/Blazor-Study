using BusinessLogicLayer.Classes;
using InterfaceLayer.Dtos;

namespace BusinessLogicLayer.Interfaces
{
    public interface IProductContainer
    {
        Product GetProductById(int id);
        IEnumerable<Product> GetAllProducts(string? filter = null);
        
        bool AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool ArchiveProduct(int id);
        
        List<SampleModel>? GetAllSampleDto();
        SampleModel? GetSampleDtoById(int id);
    }
}
