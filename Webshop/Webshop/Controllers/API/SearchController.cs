using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Webshop.Controllers.API;

[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    private readonly IProductContainer _productContainer;

    public SearchController(IProductContainer productContainer, INotyfService notyfService)
    {
        _productContainer = productContainer;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var products = _productContainer.GetAllAvailableProducts();
        return Ok(products);
    }


    [HttpGet("{search}")]
    public IActionResult SearchProducts(string search)
    {
        var products = new List<Product>();
        
        try
        {
            if (search == null)
            {
                return BadRequest("Search string is null");
            }
    
            if (search.Length < 3)
            {
                return BadRequest("Search string is too short");
            } 
    
            products = _productContainer.SearchProducts(search).ToList();
            if (!products.Any())
            {
                return NotFound();
            }
            
            return Ok(products);
    
        }
        catch (Exception e)
        {
            return NotFound();
        }
    }
    
    [HttpPost]
    public IActionResult Search([FromBody] string searchQuery)
    {
        IEnumerable<Product> products = new List<Product>();
        if (!string.IsNullOrEmpty(searchQuery)){
            products = _productContainer.SearchProducts(searchQuery);
        }
        return new JsonResult(products);
    }
}