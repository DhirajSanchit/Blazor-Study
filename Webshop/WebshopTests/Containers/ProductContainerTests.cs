using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Containers;
using BusinessLogicLayer.Interfaces;
using InterfaceLayer.Dtos;
using WebshopTests.Mocks.DALs;

namespace WebshopTests.Containers;

public class ProductContainerTests
{
    [Fact]
    public void Converts_DtoList_To_Product_List()
    {
        // Arrange
        var mockDal = ProductDALMock.GetProductDALMock();
        IProductContainer productContainer = new ProductContainer(mockDal.Object);

        // Act
        var dtos = productContainer.GetAllAvailableProducts();

        //Assert
        Assert.All(dtos, product => Assert.IsType<Product>(product));
    }
    
    [Fact]
    public void Throws_Exception_When_Exception_Is_Received()
    {
        // Arrange
        var mockDal = ProductDALMock.GetProductDALMock();
        mockDal.Setup(x => x.GetAllAvailableProducts()).Throws(new Exception());
        IProductContainer productContainer = new ProductContainer(mockDal.Object);

        // Act
        
        //Assert
        Assert.Throws<Exception>(() => productContainer.GetAllAvailableProducts());
    }

    [Fact]
    public void Converts_DtoList_To_Product_List_Exception()
    {
        // Arrange
        var mockDal = ProductDALMock.GetProductDALMock();
        IProductContainer productContainer = new ProductContainer(mockDal.Object);

        // Act
        var dtos = productContainer.GetAllAvailableProducts();

        //Assert
        Assert.All(dtos, product => Assert.IsType<Product>(product));
    }

    [Theory]
    [InlineData("st")]
    [InlineData("ea")]
    public void Search_Returns_Correct_Products_By_SearchQuery(string searchquery)
    {
        // Arrange
        var mockDal = ProductDALMock.GetProductDALMock();
        IProductContainer productContainer = new ProductContainer(mockDal.Object);

        // Act
        var dtos = productContainer.SearchProducts(searchquery);

        //Assert
        Assert.All(dtos, dto => dto.Name.Contains(searchquery));
        Assert.All(dtos, product => Assert.IsType<Product>(product));
    }
    
    [Fact]
    public void Search_Returns_Throws_Exception()
    {
        // Arrange
        var mockDal = ProductDALMock.GetProductDALMock();
        mockDal.Setup(x => x.SearchProducts(It.IsAny<string>())).Throws(new Exception());
        IProductContainer productContainer = new ProductContainer(mockDal.Object);

        // Act
        var searchquery = "searchquery";
        
        //Assert
        Assert.Throws<Exception>(() => productContainer.SearchProducts(searchquery));
    }

    [Fact]
    public void Returns_Correct_Product_By_Id()
    {
        // Arrange
        var mockDal = ProductDALMock.GetProductDALMock();
        IProductContainer productContainer = new ProductContainer(mockDal.Object);

        // Act
        var id = 1;
        var product = productContainer.GetProductById(id);

        var outOfIndex = mockDal.Object.GetAllAvailableProducts().Count() + 1;

        //Assert
        Assert.Equal(id, product.ProductId);
        Assert.IsType<Product>(product); 
    }
    
    [Fact]
    public void Invalid_ProductId_Throws_Exception()
    {
        // Arrange
        var mockDal = ProductDALMock.GetProductDALMock();
        IProductContainer productContainer = new ProductContainer(mockDal.Object);

        // Act
        var outOfIndex = mockDal.Object.GetAllAvailableProducts().Count() + 1;

        //Assert
        Assert.Throws<NullReferenceException>(() =>productContainer.GetProductById(outOfIndex));
    }

    [Fact]
    public void Adds_Product_To_Database()
    {
        // Arrange
        var mockDal = ProductDALMock.GetProductDALMock().Object;
        IProductContainer productContainer = new ProductContainer(mockDal);


        // Act
        var listLength = mockDal.GetAllAvailableProducts().Count();

        var product = new Product()
        {
            ProductId = listLength + 1,
            Name = "Test",
            Description = "Test",
            Price = 1,
            ImageLink = "ImageLink"
        };

        productContainer.AddProduct(product);

        var lastProduct = mockDal.GetAllAvailableProducts().Last();
        var newListLength = mockDal.GetAllAvailableProducts().Count();

        //Assert
        Assert.Equal(listLength + 1, newListLength);
        Assert.Equal(product.ProductId, lastProduct.ProductId);
        Assert.Equal(product.Name, lastProduct.Name);
        Assert.Equal(product.Description, lastProduct.Description);
        Assert.Equal(product.Price, lastProduct.Price);
    } 
    
    [Fact]
    public void Cannot_Add_Null_Product_To_Database_Throws_Exception()
    {
        // Arrange
        var mockDal = ProductDALMock.GetProductDALMock();
        mockDal.Setup(x => x.AddProduct(It.IsAny<ProductDto>())).Throws(new Exception());
        IProductContainer productContainer = new ProductContainer(mockDal.Object);
        
        // Act 
        var product = new Product();

        //Assert
        Assert.Throws<Exception>(() => productContainer.AddProduct(product));
    }
    
    
    [Fact]
    //Testmethod that tests if the method UpdateProduct in the ProductContainer class works as intended
    public void Updates_Product_In_Database()
    {
        // Arrange
        var mockDal = ProductDALMock.GetProductDALMock();
        IProductContainer productContainer = new ProductContainer(mockDal.Object);

        // Act
        var product = new Product()
        {
            ProductId = 1,
            Name = "Test",
            Description = "Test",
            Price = 1,
            ImageLink = "ImageLink"
        };

        productContainer.UpdateProduct(product); 

        //Assert
        Assert.True(productContainer.UpdateProduct(product));
    }
    
    [Fact]
    public void Cannot_Update_Null_Product_To_Database_Throws_Exception()
    {
        // Arrange
        var mockDal = ProductDALMock.GetProductDALMock();
        mockDal.Setup(x => x.UpdateProduct(It.IsAny<ProductDto>())).Throws(new Exception());
        IProductContainer productContainer = new ProductContainer(mockDal.Object);
        
        // Act 
        var product = new Product();

        //Assert
        Assert.Throws<Exception>(() => productContainer.UpdateProduct(product));
    }
    
    [Fact]
    public void Archives_Product_In_Database()
    {
        // Arrange
        var mockDal = ProductDALMock.GetProductDALMock();
        IProductContainer productContainer = new ProductContainer(mockDal.Object);

        // Act
        var product = new Product()
        {
            ProductId = 1,
            Name = "Test",
            Description = "Test",
            Price = 1,
            ImageLink = "ImageLink"
        }; 

        //Assert
        Assert.True(productContainer.ArchiveProduct(product.ProductId));
    }
    
    [Fact]
    public void Cannot_Archive_Null_Product_To_Database_Throws_Exception()
    {
        // Arrange
        var mockDal = ProductDALMock.GetProductDALMock();
        mockDal.Setup(x => x.ArchiveProduct(It.IsAny<int>(), It.IsAny<DateTime>())).Throws(new Exception());
        IProductContainer productContainer = new ProductContainer(mockDal.Object);
        
        // Act 
        var product = new Product();
        
        //Assert
        Assert.False(productContainer.ArchiveProduct(product.ProductId));
    }
}