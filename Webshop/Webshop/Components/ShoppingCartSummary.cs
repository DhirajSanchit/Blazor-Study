using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Webshop.Models;
using Webshop.Models.Components;

namespace Webshop.Components;

public class ShoppingCartSummary : ViewComponent
{
    private readonly IShoppingCart _shoppingCart;
    
    public ShoppingCartSummary(IShoppingCart shoppingCart)
    {
        _shoppingCart = shoppingCart;
    }
    
    public IViewComponentResult Invoke()
    {
        var items = _shoppingCart.GetShoppingCartItems();
        _shoppingCart.ShoppingCartItems = items;

        var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());
        return View(shoppingCartViewModel);
    }
}