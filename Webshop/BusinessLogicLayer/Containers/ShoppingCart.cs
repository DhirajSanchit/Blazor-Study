using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Interfaces;
using InterfaceLayer.DALs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer.Containers;

public class ShoppingCart : IShoppingCart
{
    private readonly IShoppingCartDAL _shoppingCartDAL;
    private IProductDAL _productDAL;
    private IOrderDAL _orderDAL;
    
    //Create unit of work
    //For 3 repos

    public string? ShoppingCartId { get; set; }
    public List<ShoppingCartItem> ShoppingCartItems { get; set; }

    public ShoppingCart(IShoppingCartDAL shoppingCartDAL, IProductDAL productDal, IOrderDAL orderDal)
    {
        _shoppingCartDAL = shoppingCartDAL;
        _productDAL = productDal;
        _orderDAL = orderDal;
    }

    public void AddToCart(Product product)
    {
        try
        {
            var shoppingCartItem = new ShoppingCartItem
            {
                ShoppingCartId = ShoppingCartId,
                Product = product,
                Amount = 1,
            };
            _shoppingCartDAL.AddToCart(shoppingCartItem.toDto());
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            throw;
        }
    }

    ///This code runs when the user visits the site
    ///It checks if the user has a shopping cart id, if not it creates one, stores it in a GUID and stores it in a cookie
    ///When the user returns to the site, the cookie is checked and the shopping cart id is retrieved
    public static ShoppingCart GetCart(IServiceProvider services)
    {
        ISession? session = services.GetRequiredService<IHttpContextAccessor>()?
            .HttpContext.Session;

        IShoppingCartDAL context = services.GetService<IShoppingCartDAL>() ?? throw new Exception("Error initializing");
        IProductDAL _productDal = services.GetService<IProductDAL>() ?? throw new Exception("Error initializing");
        IOrderDAL _orderDal = services.GetService<IOrderDAL>() ?? throw new Exception("Error initializing");

        string? cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

        //Code below is to make sure that the cartId is stored in the session, Commented due to errors and bugfixes
        // string? cartId = session.Keys.Contains("CartId") ? session.GetString("CartId") : Guid.NewGuid().ToString();
        session.SetString("CartId", cartId);

        return new ShoppingCart(context, _productDal, _orderDal) { ShoppingCartId = cartId };
    }

    public bool RemoveFromCart(Product product)
    {
        ShoppingCartItem item;
        try
        {
            item = new ShoppingCartItem();
            item.Product = product;
            item.ShoppingCartId = ShoppingCartId;
            return _shoppingCartDAL.RemoveFromCart(item.toDto());
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            throw;
        }
    }


    //Method to retrieve all shoppingcart items tied to user
    //TODO: Revise Method below to a cleaner one, possible Unit of work
    public List<ShoppingCartItem> GetShoppingCartItems()
    {
        List<ShoppingCartItem> shoppingCartItems = new();
        try
        {
            var dataset = _shoppingCartDAL.GetShoppingCartItems(ShoppingCartId);
            foreach (var record in dataset)
            {
                var product = new Product(_productDAL.GetProductById(record.ProductId));
                shoppingCartItems.Add(new ShoppingCartItem(record, product));
            }

            return shoppingCartItems;
        }
        catch (NullReferenceException exception)
        {
            Console.WriteLine(exception.Message);
            return shoppingCartItems;
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            throw;
        }
    }

    public bool ClearCart()
    {
        try
        {
            return _shoppingCartDAL.ClearCart(ShoppingCartId);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            throw;
        }
    }

    public ShoppingCartItem GetShoppingCartItem(int productId, string? cartId)
    {
        try
        {
            return new ShoppingCartItem(_shoppingCartDAL?.CheckCart(productId, cartId));
        }
        catch (NullReferenceException nre)
        {
            Console.WriteLine("NullReferenceException: " + nre.Message);
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new ShoppingCartItem();
        }
    }

    public decimal GetShoppingCartTotal()
    {
        
        //calculate total price of shopping cart
        decimal total = 0;
        if (ShoppingCartItems != null)
        {
            foreach (var item in ShoppingCartItems)
            {
                total += item.Product.Price * item.Amount;
            }
        }

        return total;
    }
}