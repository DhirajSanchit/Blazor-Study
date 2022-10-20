using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Interfaces;
using InterfaceLayer.DALs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer.Containers;

public class ShoppingCart : IShoppingCart
{
    private readonly IShoppingCartDAL _shoppingCartDAL;
    public string? ShoppingCartId { get; set; }

    public ShoppingCart(IShoppingCartDAL shoppingCartDAL)
    {
        _shoppingCartDAL = shoppingCartDAL;
    }

    public void AddToCart(Product product)
    {
        // var shoppingCartItem = _shoppingCartDAL.GetShoppingCartItems(ShoppingCartId, product.ProductId);
        // if (shoppingCartItem == null)
        // {
        //     shoppingCartItem = new ShoppingCartItem
        //     {
        //         Product = product,
        //         ShoppingCartId = ShoppingCartId,
        //         Amount = 1,
        //     };
        //     _shoppingCartDAL.AddToCart(shoppingCartItem.toDto());
        // }
        // else
        // {
        //     shoppingCartItem.Amount++;
        //    // _shoppingCartDAL.UpdateShoppingCartItem(shoppingCartItem);
        // }
    }

    public int RemoveFromCart(Product product)
    {
        throw new NotImplementedException();
    }

    public List<ShoppingCartItem> GetShoppingCartItems()
    {
        throw new NotImplementedException();
    }

    public void ClearCart()
    {
        throw new NotImplementedException();
    }

    public decimal GetShoppingCartTotal()
    {
        throw new NotImplementedException();
    }

    public List<ShoppingCartItem> ShoppingCartItems { get; set; }

    public static ShoppingCart GetCart(IServiceProvider services)
    {
        ISession? session = services.GetRequiredService<IHttpContextAccessor>()?
            .HttpContext.Session;
        
        var context = services.GetService<IShoppingCartDAL>();
        string? cartId = session.Keys.Contains("CartId") ? session.GetString("CartId") : Guid.NewGuid().ToString();
        session.SetString("CartId", cartId);
        
        return new ShoppingCart(context) { ShoppingCartId = cartId };
    }
}