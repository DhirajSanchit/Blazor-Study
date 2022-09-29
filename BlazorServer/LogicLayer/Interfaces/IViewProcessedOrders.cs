using LogicLayer.Models;

namespace LogicLayer.Interfaces;

public interface IViewProcessedOrders
{
    IEnumerable<Order> Execute();
}