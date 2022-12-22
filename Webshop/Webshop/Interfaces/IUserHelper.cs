using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Webshop.Models;

namespace Webshop.Interfaces;

public interface IUserHelper
{
    dynamic GetUserId(ClaimsPrincipal user);
    IActionResult NavigateByRole(ClaimsPrincipal user);
    bool CurrentlyLoggedIn();
    Task<IActionResult> Authenticate(LoginModel model);
    
}