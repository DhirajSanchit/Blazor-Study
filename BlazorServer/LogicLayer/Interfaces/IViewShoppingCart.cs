using LogicLayer.Models;

namespace LogicLayer.Interfaces;

public interface IViewShoppingCart
{
    Task<Order> Execute();
}