using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Containers;
using InterfaceLayer.DALs;
using WebshopTests.Mocks;

namespace WebshopTests.Containers;


public class ProductContainerTests
{
    static IProductDAL _productDal = new ProductDalMock();
    ProductContainer productContainer = new ProductContainer(_productDal);
    
    [Fact]
    public void GetProductById_WhenProductExists_ReturnsProduct()
    {
        // Arrange
      
        
        var product = new Product();
        productContainer.AddProduct(product);

        // Act
        var result = productContainer.GetProductById(product.ProductId);

        // Assert
        Assert.Equal(product, result);
    }
}