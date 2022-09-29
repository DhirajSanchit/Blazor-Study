using DataLayer.Dtos;

namespace DataLayer.Interfaces;

public interface IOrderDal
{
    
    public IList<LineItemDto> GetAll();
    public LineItemDto GetById(int id);
    public LineItemDto SaveProduct(int id);
    public LineItemDto DeleteOrder(int id);
}