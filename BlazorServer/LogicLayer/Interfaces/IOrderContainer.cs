using LogicLayer.Models;

namespace LogicLayer.Interfaces;

public interface IOrderContainer
{
    Order CreateNewOrder(Order order);
    Order GetOrder(int OrderId);
    Order GetOrderId(string uniqueId);
    int CreateOrder(Order order);
    void UpdateOrder(Order order);
    IEnumerable<Order> GetOrders();
    IEnumerable<Order> GetOutstandingOrders();
    IEnumerable<Order> GetProcessedOrders();
    IEnumerable<LineItem> GetLineItemsByOrderId(int id);
    Order GetOrderByUniqueId(string uniqueId);
    
}