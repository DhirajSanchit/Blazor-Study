using InterfaceLayer.DALs;
using InterfaceLayer.Dtos;

namespace WebshopTests.Mocks;

public class ProductDalMock : IProductDAL
{
    public ProductDto GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ProductDto> GetAllProducts(string filter = null)
    {
        throw new NotImplementedException();
    }

    public bool AddProduct(ProductDto dto)
    {
        throw new NotImplementedException();
    }

    public bool UpdateProduct(ProductDto product)
    {
        throw new NotImplementedException();
    }

    public bool ArchiveProduct(int id, DateTime archiveDate)
    {
        throw new NotImplementedException();
    }
    
    
    public List<SampleDto>? getSampleData()
    {
        throw new NotImplementedException();
    }

    public SampleDto? getSampleDataById(int id)
    {
        throw new NotImplementedException();
    }
}