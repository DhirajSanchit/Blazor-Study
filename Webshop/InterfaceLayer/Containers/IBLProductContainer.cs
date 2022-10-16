using System.Collections.Generic;
using InterfaceLayer.Dtos; 

namespace InterfaceLayer.Containers
{
    public interface IBLProductContainer
    {
        ProductDto GetProductById(int id);
        IEnumerable<ProductDto> GetAllProducts(string filter = null);        
    }
}
