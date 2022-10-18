using System.Diagnostics;
using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Webshop.Models;

namespace Webshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductContainer _container;

    public HomeController(ILogger<HomeController> logger, IProductContainer productContainer)
    {
        _logger = logger;
        _container = productContainer;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Products()
    {
        ProductViewModel pvm = new();
        pvm._Products = _container.GetAllProducts();
        return View(pvm);
    }


    [HttpGet]
    public IActionResult ProductDetails(int id)
    {
        Product product = new Product();
        try
        {
            product = _container.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
        }
        catch (Exception e)
        {
            
            _logger.LogError(e.Message);
            RedirectToAction("Error", "Home");
        }
        return View(product);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}