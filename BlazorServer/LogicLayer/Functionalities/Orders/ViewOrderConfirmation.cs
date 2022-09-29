using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace LogicLayer.Functionalities.Orders;

public class ViewOrderConfirmation : IViewOrderConfirmation
{
    private readonly IOrderContainer _container;

    public ViewOrderConfirmation(IOrderContainer container)
    {
        this._container = container;
    }

    public Order Execute(string uniqueId)
    {
        return _container.GetOrderByUniqueId(uniqueId);
    }
}
