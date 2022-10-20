using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Webshop.Models;

namespace Webshop.Controllers;

public class ShoppingCartController : Controller
{
    private readonly IProductContainer _productRepository;
    private readonly IShoppingCart _shoppingCart;

    public ShoppingCartController(IProductContainer productRepository, IShoppingCart
        shoppingCart)
    {
        _productRepository = productRepository;
        _shoppingCart = shoppingCart;
    }
    
    
    public IActionResult Index()
    {
        var items = _shoppingCart.GetShoppingCartItems();
        _shoppingCart.ShoppingCartItems = items;
        var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());
        
        return View(shoppingCartViewModel);
    }
    
    public RedirectToActionResult AddToShoppingCart(int productId)
    {
        var selectedProduct = _productRepository.GetAllProducts().FirstOrDefault(p => p.ProductId == productId);
        if (selectedProduct != null)
        {
            _shoppingCart.AddToCart(selectedProduct);
        }
        return RedirectToAction("Index");
    }
    
    public RedirectToActionResult RemoveFromShoppingCart(int productId)
    {
        var selectedProduct = _productRepository.GetAllProducts().FirstOrDefault(p => p.ProductId == productId);
        if (selectedProduct != null)
        {
            _shoppingCart.RemoveFromCart(selectedProduct);
        }
        return RedirectToAction("Index");
    }
}