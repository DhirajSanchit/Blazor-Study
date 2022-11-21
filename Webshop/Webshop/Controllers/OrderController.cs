using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Webshop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderContainer _orderContainer;
        private readonly IShoppingCart _shoppingCart;
        private INotyfService _notyfService;

        public OrderController(IOrderContainer orderContainer, IShoppingCart shoppingCart, INotyfService notyfService)
        {
            _orderContainer = orderContainer;
            _shoppingCart = shoppingCart;
            _notyfService = notyfService;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            if (items.Count == 0)
            {
                _notyfService.Warning("Your cart is empty, add some products first");
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            try
            {
                var items = _shoppingCart.GetShoppingCartItems();
                _shoppingCart.ShoppingCartItems = items;

                if (_shoppingCart.ShoppingCartItems.Count == 0)
                {
                    ModelState.AddModelError("", "Your cart is empty, add some products first");
                }
                
                if (ModelState.IsValid)
                {
                    if (_orderContainer.CreateOrder(order))
                    {
                        _shoppingCart.ClearCart();
                        _notyfService.Success("Order created successfully");
                        return RedirectToAction("CheckoutComplete");
                    }
                    else
                    {
                        _notyfService.Error("Something went wrong");
                        return RedirectToAction("Index", "Home");
                    }
                }

                return View(order);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                _notyfService.Error(e.Message);
                return View(order);
            }
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order!";
            return View();
        }
    }
}