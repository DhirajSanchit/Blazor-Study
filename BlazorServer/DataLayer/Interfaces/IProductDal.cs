using DataLayer.Dtos;

namespace DataLayer.Interfaces;

public interface IProductDal
{
    public IList<ProductDto> GetAll();

}