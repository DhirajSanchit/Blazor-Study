using LogicLayer.Models;

namespace LogicLayer.Interfaces;

public interface IViewOrderDetails
{
    Order Execute(int orderId);
}