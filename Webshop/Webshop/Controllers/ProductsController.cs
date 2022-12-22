using System.Diagnostics;
using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webshop.Helpers.ViewModelHelpers;
using Webshop.Models;

namespace Webshop.Controllers;

//TODO: NotyF refactor to use methods with a switch statement
public class ProductsController : Controller
{
    private ILogger _logger;
    private readonly IProductContainer _productContainer;
    private INotyfService _notyfService;

    private bool result = false;
    private Product product;


    public ProductsController(ILogger<ProductsController> logger, IProductContainer productContainer,
        INotyfService notyfService)
    {
        _logger = logger;
        _productContainer = productContainer;
        _notyfService = notyfService;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        try
        {
            ProductViewModel pvm = new();
            pvm._Products = _productContainer.GetAllAvailableProducts();
            if (pvm == null)
            {
                return NotFound();
            }
            
            //Method below is used to redirect to a page with a blazor searchbar component.
            // return Redirect("/app");
            
            return View(pvm);
        }

        //TODO: catch the specific exceptions
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return RedirectToAction("Error", "Home");
            
        }
    }

    
    [HttpGet]
    [IgnoreAntiforgeryToken]
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

    [Authorize(Policy = "AdminOrShopOwner")]
    [HttpGet]
    public IActionResult AddProduct()
    {
        return View();
    }

    [Authorize(Policy = "AdminOrShopOwner")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddProduct(Product product)
    {
        //TODO: Add product to database 
        if (ModelState.IsValid)
        {
            try
            {
                result = _productContainer.AddProduct(product);
                if (result)
                {
                    _notyfService.Success("Product Added!", 10);
                    RedirectToAction(nameof(Index));
                }
                else
                {
                    _notyfService.Warning("Something went wrong", 10);
                    RedirectToAction(nameof(AddProduct));
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                ErrorViewModel evm = new ErrorViewModel();
                evm.ErrorMessage = e.Message;
                return RedirectToAction("Error", "Products");
            }
        }
        return View();
    }


    [Authorize(Policy = "AdminOrShopOwner")]
    //TODO implement the rest of the CRUD operations
    [HttpGet]
    public IActionResult EditProduct(int id)
    {
        product = new();
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


    [Authorize(Policy = "AdminOrShopOwner")]
    //TODO: Finish route
    [HttpPost]
    [ValidateAntiForgeryToken]
    // [ValidateAntiForgeryToken]
    public IActionResult EditProduct(Product product, int id)
    {
        if (ModelState.IsValid)
        {
            product.ProductId = id;
            try
            {
                result = _productContainer.UpdateProduct(product);
                if (!result)
                {
                    _notyfService.Warning("Something went wrong", 10);
                    return RedirectToAction("EditProduct", "Products", new { @id = id });
                }
                else
                {
                    _notyfService.Success("Product Editted!", 10);
                    return RedirectToAction("EditProduct", "Products", new { @id = id });
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                ErrorViewModel evm = new ErrorViewModel();
                evm.ErrorMessage = e.Message;
                return RedirectToAction("Error", "Products");
            }
        }
        return View();
    }
    
    [Authorize(Policy = "AdminOrShopOwner")]
    public IActionResult ArchiveProduct(int id)
    {
        try
        {
            var result = _productContainer.ArchiveProduct(id);
            if (result)
            {
                _notyfService.Success("Archive status processed!", 10);
                return RedirectToAction("Assortment");
            }
            else
            {
                _notyfService.Warning("Something went wrong", 10);
                RedirectToAction("Assortment");
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return NotFound();
        }

        return RedirectToAction("Assortment", "Products");
    }
    
    [Authorize(Policy = "AdminOrShopOwner")]
    [HttpGet]
    public IActionResult Assortment()
    {
        try
        {
            //var assortment = List<AssortmentViewModel> = _productContainer.GetAllProducts();
            var assortment = _productContainer.GetAssortment();
            var viewModels = AssortmentViewModelHelper.ToAssortmentViewModelList(assortment);
            
            if (viewModels == null)
            {
                return NotFound();
            }

            return View(viewModels);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return RedirectToAction("Error", "Home");
            
        }
    }

    public IActionResult Search()
    {
        return View();
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    
}