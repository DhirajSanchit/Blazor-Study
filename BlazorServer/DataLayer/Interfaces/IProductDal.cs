using DataLayer.Dtos;

namespace DataLayer.Interfaces;

public interface IProductDal
{
    public IList<ProductDto> GetAll();
    public ProductDto GetById(int id);
    public bool UpdateProduct(ProductDto Dto);

    public bool  DeleteProduct(int id);
    public bool AddProduct(ProductDto productDto);
}