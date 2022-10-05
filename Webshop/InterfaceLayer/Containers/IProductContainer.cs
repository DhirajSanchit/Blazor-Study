using System.Collections.Generic;
using InterfaceLayer.Dtos; 

namespace InterfaceLayer.Containers
{
    public interface IProductContainer
    {
        ProductDto GetProductById(int id);
        IEnumerable<ProductDto> GetAllProducts(string filter = null);        
    }
}
