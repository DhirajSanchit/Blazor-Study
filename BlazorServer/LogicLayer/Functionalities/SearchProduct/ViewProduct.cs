using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace LogicLayer.Functionalities.SearchProduct;

public class ViewProduct : IViewProduct
{
    private readonly IProductContainer _productContainer;
    
    public ViewProduct(IProductContainer productContainer)
    {
        _productContainer = productContainer;
    }

    public Product GetProduct(int id)
    {
        try
        {
            return _productContainer.GetProduct(id);
        }
        catch(Exception ex)
        {
            throw new Exception("Something went wrong", ex);
        }
        
    }
}