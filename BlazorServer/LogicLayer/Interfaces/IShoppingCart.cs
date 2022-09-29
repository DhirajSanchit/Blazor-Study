using LogicLayer.Models;

namespace LogicLayer.Interfaces;

public interface IShoppingCart
{
    Task<Order> GetOrderAsync();
    Task<Order> AddProductAsync(Product product);
    Task<Order> UpdateQuantity(int productId, int quantity);
    Task UpdateOrderAsync(Order order);
    Task<Order> DeleteProductAsync(int productId);
    Task<Order> PlaceOrderAsync();
    Task EmptyCartAsync();
}