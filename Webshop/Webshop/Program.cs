using System.Security.Claims;
using System.Text.Json.Serialization;
using AspNetCoreHero.ToastNotification;
using BusinessLogicLayer.Containers;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.DALs;
using DataAccessLayer.DataAccess;
using InterfaceLayer.DALs;
using NToastNotify;
using AspNetCoreHero.ToastNotification.Extensions;
using BusinessLogicLayer.Classes;
using Microsoft.AspNetCore.Authentication.Cookies;
using Webshop.Helpers;
using Webshop.Helpers.AuthenticationHelpers;
using Webshop.Interfaces;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

// Add servicesFor Toasts
builder.Services.AddControllersWithViews().AddNToastNotifyToastr(new ToastrOptions
{
    ProgressBar = true,
    TimeOut = 5000
});

//Service for Toasts Notifications
builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 5;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopRight;
    // config.HasRippleEffect = true;
});

//Service for Runtime Compilation, enables Razor Pages or CSHTML Views to be edited while the app is running
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(
    options => { options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });
builder.Services.AddRazorPages();

//Code below used mainly for Proof Of Concept and debugging purposes
var connectionstring = builder.Configuration.GetConnectionString("Default");


//DI Services
builder.Services.AddTransient<IDataAccess>(sp => new DataAccess(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IProductDAL, ProductDAL>();
builder.Services.AddScoped<IProductContainer, ProductContainer>();

//Orders
builder.Services.AddScoped<IOrderDAL, OrderDAL>();
builder.Services.AddScoped<IOrderContainer, OrderContainer>();

//Authentication & Authorization
builder.Services.AddScoped<IUserContainer, UserContainer>();
builder.Services.AddScoped<IUserDAL, UserDAL>();

//ShoppingCart 
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddScoped<IShoppingCartDAL, ShoppingCartDAL>();

//Proof of Concept flow, used for development purposes
builder.Services.AddScoped<IProofOfConceptsDAL, ProofOfConceptsDAL>();
builder.Services.AddScoped<IProofOfConceptsContainer, ProofOfConceptsContainer>();

builder.Services.AddSession(options =>
{
    // options.IdleTimeout = TimeSpan.FromDays(10);
    //options.Cookie.IsEssential = true;
    options.Cookie.Name = "ShoppingCart";
});


//Authentication
builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        //o.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    })
    .AddCookie();


//Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("ShopOwner", policy => policy.RequireRole("ShowpOwner"));
    options.AddPolicy("Customer", policy => policy.RequireRole("Customer"));
    
    //Multiple roles policy for everything except admin
    options.AddPolicy("UserOrGuest", policy => policy.RequireRole("ShowpOwner", "Customer"));
    options.AddPolicy("AdminOrShopOwner", policy => policy.RequireRole("ShowpOwner", "Admin"));
});

//Helper services
builder.Services.AddScoped<IUserHelper, UserHelper>();

builder.Services.AddRazorPages();

builder.Services.AddServerSideBlazor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseNToastNotify();
app.UseNotyf();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/app/{*catchall}", "/App/Index");

app.Run();