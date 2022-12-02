using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.DALs;
using DataAccessLayer.DataAccess;
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
        Product selectedProduct = new();
        try
        {
            selectedProduct = _productContainer.GetProductById(productId);
            if (selectedProduct != null)
            {
                if (_shoppingCart.AddToCart(selectedProduct)) ;
                {
                    _notyfService.Success($"Product {selectedProduct.Name} added to cart", 3);
                    return RedirectToAction("Index");
                }
            }

            _notyfService.Error("Product couldn't be added", 3);
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            _notyfService.Error(e.Message);
            Console.WriteLine(e);
            return RedirectToAction("Index", "Home");
        }

        return RedirectToAction("Index");
    }


    public RedirectToActionResult RemoveFromShoppingCart(int id)
    {
        if (id != 0)
        {
            var selectedProduct = _productContainer.GetProductById(id);
            try
            {
                if (_shoppingCart.RemoveFromCart(selectedProduct))
                {
                    _notyfService.Success($"Product {selectedProduct.Name} removed from cart");
                    return RedirectToAction("Index", "ShoppingCart");
                }
            }
            catch (NullReferenceException e)
            {
                _notyfService.Error(e.Message);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                _notyfService.Error(e.Message);
                Console.WriteLine(e);
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index");
        }

        _notyfService.Error("Product not found", 5);
        return RedirectToAction("Index");
    }

    public RedirectToActionResult ClearCart()
    {
        try
        {
            _shoppingCart.ClearCart();
            _notyfService.Information("Cart Emptied", 5);
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            _notyfService.Error(e.Message);
            Console.WriteLine(e);
            return RedirectToAction("Index", "Home");
        }
    }
}