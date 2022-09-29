using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace LogicLayer.Functionalities.ShoppingCart;

public class ViewShoppingCart : IViewShoppingCart
{
    private readonly IShoppingCart _shoppingCart;

    public ViewShoppingCart(IShoppingCart shoppingCart)
    {
        _shoppingCart = shoppingCart;
    }

    public Task<Order> Execute()
    {
        return _shoppingCart.GetOrderAsync();
    }
}