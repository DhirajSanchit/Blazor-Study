using BusinessLogicLayer.Interfaces;

namespace Webshop.Models;

public class ShoppingCartViewModel
{
    public ShoppingCartViewModel(IShoppingCart shoppingCart, decimal shoppingCartTotal)
    {
        ShoppingCart = shoppingCart;
        ShoppingCartTotal = shoppingCartTotal;
    }

    public IShoppingCart ShoppingCart { get; }
    public decimal ShoppingCartTotal { get; }
}