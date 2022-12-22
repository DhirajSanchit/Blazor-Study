using InterfaceLayer.Dtos;

namespace InterfaceLayer.DALs
{
    public interface IProductDAL
    {
        ProductDto GetProductById(int id);
        IEnumerable<ProductDto> GetAllAvailableProducts();
        bool AddProduct(ProductDto dto);
        bool UpdateProduct(ProductDto product);
        bool HandleArchivation(int id);
        IEnumerable<ProductDto> SearchProducts(string filter = null);
        List<ProductDto> GetAssortment();
        bool ArchiveProduct(int id,  DateTime archiveDate);

    }
}