using BusinessLogicLayer.Classes; 

namespace Webshop.Models;

public class ProductViewModel
{
    public Product? Product;
    public IEnumerable<Product>? _Products { get; set; }
    
    //TODO:
    //Update viewmodel to contain userreviews
    //Update ViewModel to contain correct images

}
