using System.Collections.Generic;
using InterfaceLayer.Dtos; 

namespace InterfaceLayer.DALs
{
    public interface IProductDAL
    {
        ProductDto GetProductById(int id);
        IEnumerable<ProductDto> GetAllProducts(string filter = null);        
    }
}
