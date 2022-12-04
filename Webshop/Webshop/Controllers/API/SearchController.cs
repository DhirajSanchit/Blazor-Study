using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Webshop.Controllers.API;

[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    private readonly IProductContainer _productContainer;

    public SearchController(IProductContainer productContainer)
    {
        _productContainer = productContainer;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    { 
        var products = _productContainer.GetAllProducts();
        return Ok(products);
    }
    
    
    [HttpGet("{search}")]
    public IActionResult SearchProducts(string search)
    {
        try
        {
            var products = _productContainer.SearchProducts(search);
            return Ok(products);
        }
        catch (Exception e)
        {
            return NotFound();
        }
    }
    
}