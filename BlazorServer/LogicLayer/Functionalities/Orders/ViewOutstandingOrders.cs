using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace LogicLayer.Functionalities.Orders;

public class ViewOutstandingOrders : IViewOutstandingOrders
{
     
        private readonly IOrderContainer _container;

        public ViewOutstandingOrders(IOrderContainer container)
        {
            this._container = container;
        }

        public IEnumerable<Order> Execute()
        {
            return _container.GetOutstandingOrders();
        }
}