using InterfaceLayer.Dtos;

namespace InterfaceLayer.DALs;

public interface IOrderDAL
{
    int CreateOrder(OrderDto Dto);
}