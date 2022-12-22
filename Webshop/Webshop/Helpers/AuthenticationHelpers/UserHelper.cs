using System.Security.Claims;
using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Webshop.Interfaces;
using Webshop.Models;

namespace Webshop.Helpers.AuthenticationHelpers;

// This class is used to retrieve specific data from the user and sessions
public class UserHelper : Controller, IUserHelper
{
    private INotyfService _notyf;
    private readonly IUserContainer _userContainer;
    
    public UserHelper(INotyfService notyf, IUserContainer userContainer)
    {
        _notyf = notyf;
        _userContainer = userContainer;
    }

    public dynamic GetUserId(ClaimsPrincipal user)
    {
        //return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        
        try
        {
            // Get the user id from the session
            return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
        catch (ArgumentNullException ane)
        {   
            _notyf.Error("No user found");
            RedirectToAction("Login", "Account");
            return null;
        }
        catch (NullReferenceException nre)
        {
            //No one is logged in, go to login page
            RedirectToAction("Login", "Account");
            return null;
        } 
        catch(Exception ex)
        {
            //Something went wrong, console log with string interpolation
            Console.WriteLine($"Something went wrong: {ex}");
            
            //Something went wrong, show error message
            _notyf.Error("Something went wrong");
            RedirectToAction("Login", "Account");
            return null;
        }
    }

   //Method that checks the user role and redirects to the correct page via switch statement
    public IActionResult NavigateByRole(ClaimsPrincipal user)
    {
        try
        {
            //Get the user role from the session
            var role = user.FindFirst(ClaimTypes.Role).Value;

            //Switch statement to check the user role
            switch (role)
            {
                case "Admin":
                    _notyf.Success("Welcome back" + user.Identity.Name);
                    return RedirectToAction("Index", "Admin");
                case "ShopOwner":
                    _notyf.Success("Welcome back" + user.Identity.Name);
                    return RedirectToAction("Privacy", "Home");
                default:
                    //do nothing
                    return LocalRedirect("/");;
            }
        }
        catch (Exception ex)
        {
            throw;
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

    public async Task<IActionResult> Authenticate(LoginModel model)
    {
        try
        {
            var user = _userContainer.GetByEmailAndPassword(model.Username, model.Password);
            if (user == null)
            {
                _notyf.Error("credentials are not correct");
                return RedirectToAction("Login", "Account");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var identity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties { IsPersistent = model.RememberMe });

            _notyf.Success("Welcome back " + user.Name);
            return LocalRedirect(model.ReturnUrl);
        }
        catch (Exception ex)
        {
            _notyf.Error("Something went wrong");
            return RedirectToAction("Login", "Account");
        }
    }




}
