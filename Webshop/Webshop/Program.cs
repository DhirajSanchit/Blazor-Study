using BusinessLogicLayer.Containers;
using DataAcessLayer.DALs;
using DataAcessLayer.DataAccess;
using InterfaceLayer.Containers;
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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();