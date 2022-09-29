using LogicLayer.Containers;
using LogicLayer.Interfaces;
using LogicLayer.Interfaces.ShoppingCart;

namespace LogicLayer.Functionalities.ShoppingCart;

public class AddToCart : IAddToCart
{
    
    private IProductContainer _container;
    private IShoppingCart _shoppingCart;
    private readonly ICartState _cartState;


    public AddToCart(IProductContainer container, IShoppingCart shoppingCart, ICartState cartState)
    {
        _container = container;
        _shoppingCart = shoppingCart;
        _cartState = cartState;
    }
    
    public async void GetProduct(int productId)
    {
        var product = _container.GetProduct(productId);
        await _shoppingCart.AddProductAsync(product);
        _cartState.UpdateLineItemsCount();
    }
}