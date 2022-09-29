using LogicLayer.Interfaces;
using LogicLayer.Interfaces.ShoppingCart;
using LogicLayer.Models;

namespace LogicLayer.Functionalities.ShoppingCart;

public class DeleteFromCart : IDeleteFromCart
{
    private readonly IShoppingCart _shoppingCart;
    private readonly ICartState _cartState;


    public DeleteFromCart(IShoppingCart shoppingCart, ICartState cartState)
    {
        _shoppingCart = shoppingCart;
        _cartState = cartState;
    }



    public async Task<Order> Execute(int productId)
    {
        var order = await _shoppingCart.DeleteProductAsync(productId);
        _cartState.UpdateLineItemsCount();
        
        return order;
    } 
}


