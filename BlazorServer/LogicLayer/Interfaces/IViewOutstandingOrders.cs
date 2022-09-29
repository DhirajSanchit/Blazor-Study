using LogicLayer.Models;

namespace LogicLayer.Interfaces;

public interface IViewOutstandingOrders
{
    IEnumerable<Order> Execute();
}