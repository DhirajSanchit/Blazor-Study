using System.Collections.Generic;
using DataLayer.Dtos;
using DataLayer.Interfaces;

namespace xUnitTests.Mocks;

public class ProductMock : IProductDal
{
    public List<ProductDto> _productDtos = new();
    //private IDalFactory _mockFactory;

    public ProductMock()
    {
        //_mockFactory = mockFactory;
        _productDtos.Add(new ProductDto()
        {
            ProductId = 1,
            CategoryId = 1,
            Brand = "Brand1",
            Description = "description1",
            ImageLink = "someUrl1",
            Name = "name1",
            Price = 90.30
        });
        _productDtos.Add(new ProductDto()
        {
            ProductId = 2,
            CategoryId = 1,
            Brand = "Brand2",
            Description = "description2",
            ImageLink = "someUrl2",
            Name = "name2",
            Price = 8.15
        });
    }

    public IList<ProductDto> GetAll()
    {
        return _productDtos;
    }

    public ProductDto GetById(int id)
    {
        var returnDto = new ProductDto();
        foreach (var dto in _productDtos)
        {
            if (dto.ProductId == id)
            {
                returnDto = dto;
            }
        }
        return returnDto;
    }    

    public bool UpdateProduct(ProductDto Dto)
    {
        throw new System.NotImplementedException();
    }

    public bool DeleteProduct(int id)
    {
       // _productDtos.Remove(productDto);
       throw new System.NotImplementedException();

    }

    public bool AddProduct(ProductDto missing_name)
    {
        throw new System.NotImplementedException();
    }
    
}
