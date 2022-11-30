using BusinessLogicLayer.Classes;
using InterfaceLayer.Dtos;

namespace BusinessLogicLayer.Interfaces
{
    public interface IOrderContainer
    {
        bool CreateOrder(Order order);
    }
}
