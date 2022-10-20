using System.Diagnostics;
using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Webshop.Models;

namespace Webshop.Controllers;

public class ProductsController : Controller
{
    private ILogger _logger;
    private readonly IProductContainer _productContainer;
    
    public ProductsController(ILogger<ProductsController> logger, IProductContainer productContainer)
    {
        _logger = logger;
        _productContainer = productContainer;
    }
    
    public IActionResult Index()
    {
        try{
            ProductViewModel pvm = new();
            pvm._Products = _productContainer.GetAllProducts();
            if(pvm == null)
            {
                return NotFound();
            }
            return View(pvm);
        }
        
        //TODO: catch the specific exceptions
        catch(Exception e){
            Debug.WriteLine(e.Message);
            return RedirectToAction("Error", "Home");
        }
    }


    [HttpGet]
    public IActionResult ProductDetails(int id)
    {
        Product product = new Product();
        try
        {
            product = _productContainer.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return NotFound();
            //TODO: Uncomment and use code below to redirect to error page
            // ErrorViewModel evm = new ErrorViewModel();
            // evm.ErrorMessage = e.Message;
            // return RedirectToAction("Error", "Home");
        } 
    }
}