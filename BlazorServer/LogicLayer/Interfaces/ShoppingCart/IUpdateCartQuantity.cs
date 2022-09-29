using LogicLayer.Models;

namespace LogicLayer.Interfaces.ShoppingCart;

public interface IUpdateCartQuantity
{
    Task<Order> Execute(int productId, int quantity);
}