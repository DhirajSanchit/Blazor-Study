using BusinessLogicLayer.Classes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webshop.Models;
using System.Security.Claims;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Webshop.Interfaces;


namespace Webshop.Helpers;

// This class is used to retrieve specific data from the user and sessions
public class UserHelper : Controller, IUserHelper
{
    private INotyfService _notyfService;
    private IUserClaimStore<User> _userClaimStore;
    public UserHelper(INotyfService notyfService)
    {
        _notyfService = notyfService;
    }

    public dynamic GetUserId(ClaimsPrincipal user)
    {
        //return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        
        try
        {
            // Get the user id from the session
            return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
        catch (ArgumentNullException)
        {   
            _notyfService.Error("Something went wrong");
            return null;
        }
        catch(Exception)
        {
            //Something went wrong
            _notyfService.Error("Something went wrong");
            RedirectToAction("Login", "Account");
            return null;
        }
    }
    
    public bool CurrentlyLoggedIn()
    {
        try
        {
            return User.Identity.IsAuthenticated;
        }   
        catch(Exception ex)
        {
            throw;
        }
    }
}
