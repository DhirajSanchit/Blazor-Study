using LogicLayer.Models;

namespace LogicLayer.Interfaces;

public interface IOrderDetails
{
    Order Execute(int orderId);
}