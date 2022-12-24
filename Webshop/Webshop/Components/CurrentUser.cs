using System.Security.Claims;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Webshop.Models.Components;

namespace Webshop.Components;

public class CurrentUser : ViewComponent
{
  
    public IViewComponentResult Invoke(ClaimsPrincipal user)
    {
        if (IsLoggedIn(user))
        {
            CurrentUserViewModel model = new CurrentUserViewModel();
            model.Name = GetUserName(user);
            return View(model);
        }
        //Do not show anything if user is not logged in
        return Content("");
    }
    
    //Return the username of the current user
    private string GetUserName(ClaimsPrincipal user)
    {
        return user.Identity.Name;
    }
    
    
    //Check if user is logged in
    private bool IsLoggedIn(ClaimsPrincipal user)
    {
        return user.Identity.IsAuthenticated;
    }
}

