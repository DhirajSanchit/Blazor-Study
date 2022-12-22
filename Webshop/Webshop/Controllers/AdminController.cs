using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Webshop.Controllers;



[Authorize(Policy = "AdminOrShopOwner")]
public class AdminController : Controller
{
    private readonly IProductContainer _productContainer;
    private INotyfService _notyfService;

    // GET

    public AdminController(IProductContainer productContainer, INotyfService notyfService)
    {
        _productContainer = productContainer;
        _notyfService = notyfService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetAssortment()
    {
        try
        {
            return RedirectToAction("Assortment", "Products");
        }
        catch (NullReferenceException e)
        {
            _notyfService.Error("Something went wrong");
            return View("Index");
        }
        catch (Exception e)
        {
            _notyfService.Error(e.Message);
            return RedirectToAction("Index");
        }
    }

    public IActionResult AddProduct()
    {
        return RedirectToAction("AddProduct", "Products");
    }
    
    public Task<IActionResult> AccessDenied()
    {
        _notyfService.Warning("You are not allowed to access this page");
        return Task.FromResult<IActionResult>(RedirectToAction("Index", "Home"));
    }
}