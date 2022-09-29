using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace LogicLayer.Functionalities.Orders;

public class ViewProcessedOrders : IViewProcessedOrders
{
    private readonly IOrderContainer _container;

    public ViewProcessedOrders(IOrderContainer container)
    {
        _container = container;
    }

    public IEnumerable<Order> Execute()
    {
        return _container.GetProcessedOrders();
    }
}