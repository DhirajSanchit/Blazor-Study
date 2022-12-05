using System.Security.Claims;
using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webshop.Interfaces;
using Webshop.Models;

namespace Webshop.Controllers;

public class AccountController : Controller
{
    private readonly IUserContainer _userContainer;
    private INotyfService _notyf;
    private IUserHelper _userHelper;
    
    public AccountController(IUserContainer userContainer, INotyfService notyf, IUserHelper userHelper)
    {
        this._userContainer = userContainer;
        _notyf = notyf;
        _userHelper = userHelper;
    }
    
    //Different signatures, redirects back to previous URL
    [AllowAnonymous]
    public IActionResult Login(string returnUrl = "/")
    {
        var id = _userHelper.GetUserId(User);
        return View(new LoginModel { ReturnUrl = returnUrl});
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginModel model)
    {
        try
        {
            var user = _userContainer.GetByUsernameAndPassword(model.Username, model.Password);
            if (user == null)
            {
                _notyf.Error("credentials are not correct");
                return RedirectToAction("Login");
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
        catch (Exception e)
        {
            _notyf.Error(e.Message);
            return RedirectToAction("Login");
        }
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        _notyf.Success("You have been logged out");
        return Redirect("/");
    }
    public Task<IActionResult> AccessDenied()
    {
        _notyf.Warning("You are not allowed to access this page");
        return Task.FromResult<IActionResult>(RedirectToAction("Login"));
    }
    
    #region Google Login Demo, not working yet
    // [AllowAnonymous]
    // public IActionResult LoginWithGoogle(string returnUrl = "/")
    // {
    //     var props = new AuthenticationProperties
    //     {
    //         RedirectUri = Url.Action("GoogleLoginCallback"),
    //         Items =
    //         {
    //             { "returnUrl", returnUrl }
    //         }
    //     };
    //     return Challenge(props, GoogleDefaults.AuthenticationScheme);
    // }

    // [AllowAnonymous]
    // public async Task<IActionResult> GoogleLoginCallback()
    // {
    //     // read google identity from the temporary cookie
    //     var result = await HttpContext.AuthenticateAsync(
    //         ExternalAuthenticationDefaults.AuthenticationScheme);
    //
    //     var externalClaims = result.Principal.Claims.ToList();
    //
    //     var subjectIdClaim = externalClaims.FirstOrDefault(
    //         x => x.Type == ClaimTypes.NameIdentifier);
    //     var subjectValue = subjectIdClaim.Value;
    //
    //     var user = _userContainer.GetByGoogleId(subjectValue);
    //
    //     var claims = new List<Claim>
    //     {
    //         new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
    //         new Claim(ClaimTypes.Name, user.Name),
    //         new Claim(ClaimTypes.Role, user.Role),
    //     };
    //
    //     var identity = new ClaimsIdentity(claims,
    //         CookieAuthenticationDefaults.AuthenticationScheme);
    //     var principal = new ClaimsPrincipal(identity);
    //
    //     // delete temporary cookie used during google authentication
    //     await HttpContext.SignOutAsync(
    //         ExternalAuthenticationDefaults.AuthenticationScheme);
    //
    //     await HttpContext.SignInAsync(
    //         CookieAuthenticationDefaults.AuthenticationScheme, principal);
    //
    //     return LocalRedirect(result.Properties.Items["returnUrl"]);
    // }
    #endregion

    
    #region GetUserID()
    //Create method that returns the current userid of the logged in user
    // public dynamic GetUserId()
    // {
    //     try
    //     {
    //         var userId = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;
    //         return int.Parse(userId);
    //     }
    //     catch (ArgumentNullException)
    //     {   
    //         return null;
    //     }
    //     catch(Exception)
    //     {
    //         //Something went wrong
    //         _notyf.Error("Something went wrong");
    //         RedirectToAction("Login");
    //         return null;
    //     }
    // }
    #endregion


}