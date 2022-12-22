using System.Security.Claims;
using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webshop.Helpers.AuthenticationHelpers;
using Webshop.Helpers.ViewModelHelpers;
using Webshop.Interfaces;
using Webshop.Models;

namespace Webshop.Controllers;

public class AccountController : Controller
{
    private readonly IUserContainer _userContainer;
    private INotyfService _notyfService;
    private IUserHelper _userHelper;

    public AccountController(IUserContainer userContainer, INotyfService notyfService, IUserHelper userHelper)
    {
        this._userContainer = userContainer;
        _notyfService = notyfService;
        _userHelper = userHelper;
    }

    //Different signatures, redirects back to previous URL
    [AllowAnonymous]
    public IActionResult Login(string returnUrl = "/")
    {
        var id = _userHelper.GetUserId(User);
        return View(new LoginModel { ReturnUrl = returnUrl });
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var user = _userContainer.GetByEmailAndPassword(model.Username.ToLower(), model.Password);
                if (user == null)
                {
                    _notyfService.Error("credentials are not correct");
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


                //if the user is an admin, redirect to the admin page
                if (user.Role == "Admin" || user.Role == "ShopOwner")
                {
                    return RedirectToAction("Index", "Admin");
                } 
                
                _notyfService.Success("Welcome back " + user.Name);
                return LocalRedirect(model.ReturnUrl);
            }
            catch (Exception e)
            {
                _notyfService.Error(e.Message);
                return RedirectToAction("Login");
            }
        }
        return View();
    }

    
    [AllowAnonymous]
    public IActionResult Register()
    {
        var id = _userHelper.GetUserId(User);
        return View(new RegistrationModel());
    }
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegistrationModel model)
    {
        if (ModelState.IsValid)
        {
            var user = AccountControllerHelper.ToUser(model);
            
            if(_userContainer.CheckForUniqueEmail(user.EmailAddress)){ 
                _notyfService.Error("Email already exists");
                return View();
            }
            
            try
            {
                
                if(_userContainer.RegisterCustomer(user))
                {
                    _notyfService.Success("You have successfully registered");
                    return RedirectToAction("Login");
                }
                _notyfService.Error("Something went wrong");
                return RedirectToAction("Register");
            }
            catch (Exception e)
            {
                _notyfService.Error(e.Message);
                return RedirectToAction("Register");
            } 
        }
        return View();
    }

    
    public async Task<IActionResult> Logout()
    {
        if (User.Identity.IsAuthenticated)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            _notyfService.Success("You have been logged out");
        }
        else
        {
            _notyfService.Error("You are not logged in");
        }

        return Redirect("/");
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

}