using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace LogicLayer.Functionalities.Orders;

public class OrderDetails : IOrderDetails
{
    private readonly IOrderContainer _container;

    public OrderDetails(IOrderContainer container)
    {
        _container = container;
    }

    public Order Execute(int orderId)
    {
        return _container.GetOrder(orderId);
    }

}