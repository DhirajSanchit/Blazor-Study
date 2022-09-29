using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorServer.Data;
using DataLayer.DALs;
using DataLayer.Factories;
using DataLayer.Helpers;
using DataLayer.Interfaces;
using LogicLayer.Containers;
using LogicLayer.Factories;
using LogicLayer.Functionalities.Orders;
using LogicLayer.Functionalities.Search;
using LogicLayer.Functionalities.ShoppingCart;
using LogicLayer.Helpers;
using LogicLayer.Interfaces;
using LogicLayer.Interfaces.ShoppingCart;

var builder = WebApplication.CreateBuilder(args);



//Todo: Clean up implementation below
var ConnectionString = builder.Configuration.GetConnectionString("LocalDockerServer");
builder.Services.AddTransient<IDbConnection>(sp => new SqlConnection(ConnectionString));
// builder.Services.AddTransient<IDbConnection>(sp => new SqlConnection("LocalDockerServer")); 
builder.Services.AddControllers();
builder.Services.AddAuthentication("BlazorServer.CookieAuth").
    AddCookie("BlazorServer.CookieAuth", config =>
    {
        config.Cookie.Name = "BlazorServer.CookieAuth";
        config.LoginPath = "/authenticate";
    });

builder.Services.AddAuthentication("BlazorServer.CookieAuth");

//'Global' Factories
builder.Services.AddSingleton<DalFactory>();
builder.Services.AddSingleton<ContainerFactory>();
 
builder.Services.AddTransient<IDataAccess>(sp => new DataAccess(builder.Configuration.GetConnectionString("LocalDockerServer")));

// DALS
builder.Services.AddScoped<ITestDapperDal, TestDapperDapperDal>();
builder.Services.AddTransient<IProductDal, ProductDal>();

// builder.Services.AddScoped<IUserContainer, UserContainer>();;
// builder.Services.AddScoped<IOrderDal, OrderDal>();
// builder.Services.AddScoped<IShoppingCartDal, ShoppingCartDal>();

// builder.Services.AddTransient<ProductDal>()
//     .AddTransient<IProductDal, ProductDal>(s => s.GetService<ProductDal>());

//Containers
builder.Services.AddScoped<ITestDapperContainer, TestDapperContainer>();
builder.Services.AddTransient<IProductContainer, ProductContainer>();
// builder.Services.AddScoped<IUserContainer, UserContainer>();
builder.Services.AddScoped<IOrderContainer, OrderContainer>();
// builder.Services.AddScoped<IShoppingCartContainer, ShoppingCartContainer>();

//Functionalities
builder.Services.AddTransient<ISearchProduct, SearchProduct>();
builder.Services.AddTransient<IViewProduct, ViewProduct>();

//ShoppingCart
builder.Services.AddTransient<IAddToCart, AddToCart>();
builder.Services.AddTransient<IViewShoppingCart, ViewShoppingCart>();
// builder.Services.AddTransient<IUpdateCart, UpdateCart>(); 
// builder.Services.AddTransient<IEmptyCart, EmptyCartCart>(); 
builder.Services.AddTransient<IDeleteFromCart, DeleteFromCart>();
builder.Services.AddTransient<IUpdateCartQuantity, UpdateCartQuantity>();
builder.Services.AddTransient<IPlaceOrder, PlaceOrder>();
builder.Services.AddTransient<IViewOrderConfirmation, ViewOrderConfirmation>();
// builder.Services.AddTransient<ICreateOrder, CreateOrder>(); 
// builder.Services.AddTransient<ICancelOrder, CancelOrder>();
// builder.Services.AddTransient<IAddToCart, AddToCart>();

//Orders
builder.Services.AddTransient<IOrderValidator, OrderValidator>();
builder.Services.AddTransient<IViewOutstandingOrders, ViewOutstandingOrders>();
builder.Services.AddTransient<IViewProcessedOrders, ViewProcessedOrders>();    
builder.Services.AddTransient<IViewOrderDetails, ViewOrderDetails>();
builder.Services.AddTransient<IProcessOrder, ProcessOrder>();


builder.Services.AddScoped<IShoppingCart, ShoppingCart>();
builder.Services.AddScoped<ICartState, ShoppingCartHelper>();

//Admin related


// builder.Services.AddTransient<ProductContainer>()
//     .AddTransient<IProductContainer, ProductContainer>(s => s.GetService<ProductContainer>());


// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
//
// app.UseEndpoints(endpoints =>{
//     
//     app.MapBlazorHub();
//     app.MapFallbackToPage("/_Host");
//     });

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();