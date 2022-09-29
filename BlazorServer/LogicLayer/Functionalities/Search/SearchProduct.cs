using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace LogicLayer.Functionalities.Search;

public class SearchProduct : ISearchProduct
{
    private readonly IProductContainer _productContainer;

    public SearchProduct(IProductContainer productContainer)
    {
        _productContainer = productContainer;
    }
    
    public IEnumerable<Product> Execute(string filter)
    {
        try
        {
            return _productContainer.GetSearchedProducts(filter);
        }
        catch(Exception exception)
        {
            return null;
        }
    }
}     