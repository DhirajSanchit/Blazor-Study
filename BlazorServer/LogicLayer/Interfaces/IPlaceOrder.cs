using LogicLayer.Models;

namespace LogicLayer.Interfaces;

public interface IPlaceOrder
{
    Task<string> Execute(Order order);
}