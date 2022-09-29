using LogicLayer.Interfaces;
using LogicLayer.Models;
using Microsoft.JSInterop;

namespace LogicLayer.Functionalities.ShoppingCart;

public class ShoppingCart : IShoppingCart
{
    private IProductContainer _productContainer;
    private const string cstringShoppingCart = "";
    private readonly IJSRuntime _jsRuntime;

    public ShoppingCart(IJSRuntime jsRuntime, IProductContainer productProductContainer)
    {
        _jsRuntime = jsRuntime;
        _productContainer = productProductContainer;
    }
    
    public async Task<Order> GetOrderAsync()
    {
        Console.WriteLine("GetOrderAsync Reached :)");
        var order = await GetOrder();
        return order;
        return null;
        throw new NotImplementedException();  
    }

    public async Task<Order> AddProductAsync(Product product)
    {
        var order = await GetOrder();
        order.AddProduct(product.ProductId, 1, product.Price);
        await SetOrder(order);
        return order;
    }

    public async Task<Order> UpdateQuantity(int productId, int quantity)
    {
        var order = await GetOrder();
        if (quantity < 0)
            return order;
        else if (quantity == 0)
            return await DeleteProductAsync(productId);

        var lineItem = order.LineItems.SingleOrDefault(x => x.ProductId == productId);
        if (lineItem != null) lineItem.Quantity = quantity;
        await SetOrder(order);

        return order;
    }

    public Task UpdateOrderAsync(Order order)
    {
        return SetOrder(order);
    }

    public async Task<Order> DeleteProductAsync(int productId)
    {
        var order = await GetOrder();
        order.RemoveProduct(productId);
        await SetOrder(order);
        return order;
    }

    public async Task<Order> PlaceOrderAsync()
    {
        throw new NotImplementedException();
    }

    public Task EmptyCartAsync()
    {
        return SetOrder(null);
    }
    
    private async Task<Order> GetOrder()
    {
        Order order = null; 
 
        if (order != null)
        {
            
        }
        else
        {
            order = new Order();
            await SetOrder(order);
        }

        foreach (var item in order.LineItems)
        {
            item.Product = _productContainer.GetProduct(item.ProductId);

        }
        return order;
        // var strOrder = await.jSruntime.InvokeAsync<string>("localstorage.getItem", cstringShoppingCart);
        
        
    }

    private async Task SetOrder(Order order)
    {
        await _jsRuntime.InvokeVoidAsync("","");
    }
}