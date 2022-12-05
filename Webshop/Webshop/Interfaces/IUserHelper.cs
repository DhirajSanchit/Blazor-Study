using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Webshop.Interfaces;

public interface IUserHelper
{
    dynamic GetUserId(ClaimsPrincipal user);

    bool CurrentlyLoggedIn();
    
    
}