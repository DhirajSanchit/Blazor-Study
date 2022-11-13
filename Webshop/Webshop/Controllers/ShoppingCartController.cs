using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Webshop.Models;

namespace Webshop.Controllers;

public class ShoppingCartController : Controller
{
    private readonly IProductContainer _productContainer;
    private readonly IShoppingCart _shoppingCart;
    private INotyfService _notyfService;

    public ShoppingCartController(IProductContainer productContainer, IShoppingCart
        shoppingCart, INotyfService notyfService)
    {
        _productContainer = productContainer;
        _shoppingCart = shoppingCart;
        _notyfService = notyfService;
    }


    public IActionResult Index()
    {
        var items = _shoppingCart.GetShoppingCartItems();
        _shoppingCart.ShoppingCartItems = items;
        var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());
        return View(shoppingCartViewModel);
    }

    //TODO: revise for a cleanup, this is messy
    public RedirectToActionResult AddToShoppingCart(int productId)
    {
        try
        {
            var selectedProduct = _productContainer.GetProductById(productId);
            if (selectedProduct != null)
            {
                _shoppingCart.AddToCart(selectedProduct);
                _notyfService.Success($"Product {selectedProduct.Name} added to cart");
                return RedirectToAction("Index");
            }
        } catch (Exception e)
        {
            _notyfService.Error(e.Message);
            Console.WriteLine(e);
            return RedirectToAction("Index", "Home");
        }

        return RedirectToAction("Index");
    }

    public RedirectToActionResult RemoveFromShoppingCart(int productId)
    {
        var selectedProduct = _productContainer.GetAllProducts().FirstOrDefault(p => p.ProductId == productId);
        if (selectedProduct != null)
        {
            _shoppingCart.RemoveFromCart(selectedProduct);
        }

        return RedirectToAction("Index");
    }
}