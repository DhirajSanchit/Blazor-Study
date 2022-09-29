using LogicLayer.Models;

namespace LogicLayer.Interfaces.ShoppingCart;

public interface IDeleteFromCart
{
    Task<Order> Execute(int productId);
}