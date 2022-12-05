using BusinessLogicLayer.Classes;

namespace BusinessLogicLayer.Interfaces
{
    public interface IOrderContainer
    {
        bool CreateOrder(Order order);
    }
}
