using LogicLayer.Interfaces;

namespace LogicLayer.Functionalities.Orders;

public class ProcessOrder : IProcessOrder
{
    private readonly IOrderContainer _container;
    private readonly IOrderValidator _orderValidator;

    public ProcessOrder(IOrderContainer _container, IOrderValidator orderValidator)
    {
        this._container = _container;
        _orderValidator = orderValidator;
    }

    public bool Execute(int orderId, string adminUserName )
    {
        var order = _container.GetOrder(orderId);
        order.AdminUser = adminUserName;
        order.DateProcessed = DateTime.Now;
        
            if(_orderValidator.ValidateProcessOrder(order))
            {
                _container.UpdateOrder(order);
                return true;
            }
            return false;
    }
} 