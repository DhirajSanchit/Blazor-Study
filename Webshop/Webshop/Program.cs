using BusinessLogicLayer.Containers;
using BusinessLogicLayer.Interfaces;
using DataAcessLayer.DALs;
using DataAcessLayer.DataAccess; 
using InterfaceLayer.DALs;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

//Code below used mainly for Proof Of Concept and debugging purposes
var connectionstring = builder.Configuration.GetConnectionString("Default");


//DI Services
builder.Services.AddTransient<IDataAccess>(sp => new DataAccess(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IProductDAL, ProductDAL>();
builder.Services.AddScoped<IProductContainer, ProductContainer>();

//ShoppingCart 
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp=>ShoppingCart.GetCart(sp));
builder.Services.AddScoped<IShoppingCartDAL, ShoppingCartDAL>();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();