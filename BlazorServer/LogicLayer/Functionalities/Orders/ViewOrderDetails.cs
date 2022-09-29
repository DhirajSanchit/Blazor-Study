using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace LogicLayer.Functionalities.Orders;

public class ViewOrderDetails : IViewOrderDetails
{
    private readonly IOrderContainer _container;

    public ViewOrderDetails(IOrderContainer container)
    {
        _container = container;
    }

    public Order Execute(int orderId)
    {
        return _container.GetOrder(orderId);
    }
}