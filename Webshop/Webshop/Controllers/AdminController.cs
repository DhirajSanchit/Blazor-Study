using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Webshop.Controllers;

public class AdminController : Controller
{
    // GET
    
    [Authorize(Policy = "Admin")]
    public IActionResult Index()
    {
        return View();
    }
}