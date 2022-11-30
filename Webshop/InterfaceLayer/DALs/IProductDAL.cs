using System.Collections.Generic;
using InterfaceLayer.Dtos;

namespace InterfaceLayer.DALs
{
    public interface IProductDAL
    {
        ProductDto GetProductById(int id);
        IEnumerable<ProductDto> GetAllProducts();

        bool AddProduct(ProductDto dto);
        bool UpdateProduct(ProductDto product);
        bool ArchiveProduct(int id, DateTime archiveDate);
        IEnumerable<ProductDto> SearchProducts(string filter = null);
    }
}