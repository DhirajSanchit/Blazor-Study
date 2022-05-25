using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorServer.Data;
using DataLayer.DALs;
using DataLayer.Factories;
using DataLayer.Interfaces;
using LogicLayer.Containers;
using LogicLayer.Factories;
using LogicLayer.Functionalities.SearchProduct;
using LogicLayer.Interfaces; 
var builder = WebApplication.CreateBuilder(args);

//Todo: Clean up implementation below
var ConnectionString = builder.Configuration.GetConnectionString("LocalDockerServer");
builder.Services.AddTransient<IDbConnection>(sp => new SqlConnection(ConnectionString));
// builder.Services.AddTransient<IDbConnection>(sp => new SqlConnection("LocalDockerServer")); 

//'Global' Factories
builder.Services.AddScoped<DalFactory>();
builder.Services.AddScoped<ContainerFactory>();

// DALS
builder.Services.AddScoped<ITestDapperDal, TestDapperDapperDal>();
builder.Services.AddTransient<IProductDal, ProductDal>();

// builder.Services.AddTransient<ProductDal>()
//     .AddTransient<IProductDal, ProductDal>(s => s.GetService<ProductDal>());


//Containers
builder.Services.AddScoped<ITestDapperContainer, TestDapperContainer>();
builder.Services.AddTransient<IProductContainer, ProductContainer>();

//Functionalities
builder.Services.AddTransient<ISearchProduct, SearchProduct>();
builder.Services.AddTransient<IViewProduct, ViewProduct>(); 
// builder.Services.AddTransient<ProductContainer>()
//     .AddTransient<IProductContainer, ProductContainer>(s => s.GetService<ProductContainer>());


// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();


// //

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();