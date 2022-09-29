using LogicLayer.Functionalities.ShoppingCart;
using LogicLayer.Interfaces;
using LogicLayer.Interfaces.ShoppingCart;
using LogicLayer.Models;

namespace LogicLayer.Functionalities.Search;

public class ViewProduct : IViewProduct
{
    private readonly IProductContainer _productContainer;
    private readonly IShoppingCart _shoppingCart;
    private readonly ICartState _cartState;


    public ViewProduct(IProductContainer productContainer, IShoppingCart shoppingCart, ICartState cartState)
    {
        _productContainer = productContainer;
        _shoppingCart = shoppingCart;
        _cartState = cartState;
    }

    public Product GetProduct(int id)
    {
        try
        {
            //await shoppingCart.AddProductAsync(product);
            _cartState.UpdateLineItemsCount();
            return _productContainer.GetProduct(id);
        }
        catch(NullReferenceException ex)
        {
            throw new Exception("No Products found", ex);
        }
        catch(Exception ex)
        {
            throw new Exception("Something went wrong", ex);
        }
        
        
    }
}