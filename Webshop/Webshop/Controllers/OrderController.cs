using System.Security.Claims;
using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webshop.Helpers.ViewModelHelpers;
using Webshop.Models;


namespace Webshop.Controllers
{
    
    [Authorize(Policy = "Customer")]
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
        public IActionResult Checkout(OrderViewModel ovm)
        {
            var order = OrderViewModelHelper.ToOrder(ovm);
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
                    AssignId(order);
                    
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

                return View(ovm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                _notyfService.Error(e.Message);
                return View(ovm);
            }
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order!";
            return View();
        }


        private void AssignId(Order order)
        {
            if (GetUserId() != null || GetUserId() > 0)
            {
                order.UserId = GetUserId();
            }
        } 
        
        private dynamic GetUserId()
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                return int.Parse(userId);
            }
            catch
            {
                return null;
            }
        }
        
        public Task<IActionResult> AccessDenied()
        {
            _notyfService.Warning("You are not allowed to access this page");

            if (User.IsInRole("Admin") || User.IsInRole("ShopOwner"))
            {
                return Task.FromResult<IActionResult>(RedirectToAction("Index", "Admin"));
            }

            return Task.FromResult<IActionResult>(RedirectToAction("Index", "Home"));
        }
    }
}