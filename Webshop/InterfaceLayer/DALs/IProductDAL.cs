using System.Collections.Generic;
using InterfaceLayer.Dtos; 

namespace InterfaceLayer.DALs
{
    public interface IProductDAL
    {
        ProductDto GetProductById(int id);
        IEnumerable<ProductDto> GetAllProducts(string filter = null);
        
        bool AddProduct(ProductDto dto);
        bool UpdateProduct(ProductDto product);
        bool ArchiveProduct(int id, DateTime archiveDate);
        
        List<SampleDto>? getSampleData();
        
        SampleDto? getSampleDataById(int id);
    }
}
