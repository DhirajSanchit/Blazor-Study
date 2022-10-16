using BusinessLogicLayer.Classes; 

namespace Webshop.Models;

public class ProductViewModel
{
    public Product? Product;
    public IEnumerable<Product>? _Products { get; set; }
}