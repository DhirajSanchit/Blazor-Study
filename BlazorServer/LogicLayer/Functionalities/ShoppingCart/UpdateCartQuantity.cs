using LogicLayer.Interfaces;
using LogicLayer.Interfaces.ShoppingCart;
using LogicLayer.Models;

namespace LogicLayer.Functionalities.ShoppingCart;

public class UpdateCartQuantity : IUpdateCartQuantity
{
    private readonly IShoppingCart _shoppingCart;
    private readonly ICartState _cartState;

    public UpdateCartQuantity(IShoppingCart shoppingCart, ICartState cartState)
    {
        _shoppingCart = shoppingCart;
        _cartState = cartState;
    }
    public async Task<Order> Execute(int productId, int quantity)
    {
        var order = await _shoppingCart.UpdateQuantity(productId, quantity);
        _cartState.UpdateProductQuantity();
        return order;
    }
}