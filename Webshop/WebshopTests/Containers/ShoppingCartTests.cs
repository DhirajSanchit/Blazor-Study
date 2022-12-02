using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Containers;
using BusinessLogicLayer.Interfaces;
using InterfaceLayer.Dtos;
using WebshopTests.Mocks.Containers;
using WebshopTests.Mocks.DALs;
using WebshopTests.Stub;
using Xunit.Sdk;

namespace WebshopTests.Containers;

public class ShoppingCartTests
{

    [Fact]
    public void Item_To_Cart_Has_Been_Added_Or_Updated()
    {
        // Arrange
        var shoppingCartDal = ShoppingCartDALMock.GetShoppingCartDALMock();
        var productDal = ProductDALMock.GetProductDALMock();
        var orderDal = OrderDALMock.GetOrderDALMock();

        //setup a mock for adding an item to the cart
        var shoppingCart = new ShoppingCart(shoppingCartDal.Object, productDal.Object, orderDal.Object);
        shoppingCart.ShoppingCartId = Guid.NewGuid().ToString();
        
        // Act
        var product = new Product()
        {
            ProductId = 1,
            Name = "Test",
            Price = 10,
            Description = "Test",
            ImageLink = "Test",
        };
        
        // Assert
       // Assert.Thr
       Assert.True(shoppingCart.AddToCart(product));
    }
    
    [Fact]
    public void No_Items_Could_Be_Added_Returns_False()
    {
        // Arrange
        var shoppingCartDal = ShoppingCartDALMock.GetShoppingCartDALMock();
        var productDal = ProductDALMock.GetProductDALMock();
        var orderDal = OrderDALMock.GetOrderDALMock();

        //setup a mock for adding an item to the cart
        shoppingCartDal.Setup(dal => dal.AddToCart(It.IsAny<ShoppingCartItemDto>())).Returns(0);
        var shoppingCart = new ShoppingCart(shoppingCartDal.Object, productDal.Object, orderDal.Object);
        shoppingCart.ShoppingCartId = Guid.NewGuid().ToString();
        
        // Act
        var product = new Product()
        {
            ProductId = 1,
            Name = "Test",
            Price = 10,
            Description = "Test",
            ImageLink = "Test",
        };
        
        // Assert
        // Assert.Thr
        Assert.False(shoppingCart.AddToCart(product));
    }
    
    [Fact]
    public void Container_Catches_Exception_And_Throws_It_To_Caller()
    {
        // Arrange
        var shoppingCartDal = ShoppingCartDALMock.GetShoppingCartDALMock();
        var productDal = ProductDALMock.GetProductDALMock();
        var orderDal = OrderDALMock.GetOrderDALMock();

        //setup a mock for adding an item to the cart
        shoppingCartDal.Setup(dal => dal.AddToCart(It.IsAny<ShoppingCartItemDto>())).Throws(new Exception());
        var shoppingCart = new ShoppingCart(shoppingCartDal.Object, productDal.Object, orderDal.Object);
        shoppingCart.ShoppingCartId = Guid.NewGuid().ToString();
        
        // Act
        var product = new Product()
        {
            ProductId = 1,
            Name = "Test",
            Price = 10,
            Description = "Test",
            ImageLink = "Test",
        };
        
        // Assert
        // Assert.Thr
        Assert.ThrowsAny<Exception>(()=>shoppingCart.AddToCart(product));
    }
    

    [Fact]
    public void Converts_Dtos_To_ShoppingCartItems_List()
    {
        var shoppingCartDal = ShoppingCartDALMock.GetShoppingCartDALMock();
        var productDal = ProductDALMock.GetProductDALMock();
        var orderDal = OrderDALMock.GetOrderDALMock();
        
        var shoppingCart = new ShoppingCart(shoppingCartDal.Object, productDal.Object, orderDal.Object);
        shoppingCart.ShoppingCartId = Guid.NewGuid().ToString();
        
        var shoppingCartItems = shoppingCart.GetShoppingCartItems();
        
        Assert.All(shoppingCartItems, item => Assert.IsType<ShoppingCartItem>(item));
    } 
    
    [Fact]
    public void Returns_Empty_List_On_NullR_Reference()
    {
        var shoppingCartDal = ShoppingCartDALMock.GetShoppingCartDALMock();
        var productDal = ProductDALMock.GetProductDALMock();
        var orderDal = OrderDALMock.GetOrderDALMock();
        
        shoppingCartDal.Setup(dal => dal.GetShoppingCartItems(It.IsAny<string>())).Returns(new List<ShoppingCartItemDto>());
        
        var shoppingCart = new ShoppingCart(shoppingCartDal.Object, productDal.Object, orderDal.Object);
        shoppingCart.ShoppingCartId = Guid.NewGuid().ToString();

        var items = shoppingCart.GetShoppingCartItems();
        
        // Assert if the items are empty
        Assert.Empty(items);
    } 
    
    
    [Fact]
    public void Cart_Cleared_Returns_True()
    {
        // Arrange
        var shoppingCartDal = ShoppingCartDALMock.GetShoppingCartDALMock();
        var productDal = ProductDALMock.GetProductDALMock();
        var orderDal = OrderDALMock.GetOrderDALMock();
        shoppingCartDal.Setup(dal=> dal.ClearCart(It.IsAny<string>())).Returns(true);
        // Act
        //setup a mock for adding an item to the cart
        var shoppingCart = new ShoppingCart(shoppingCartDal.Object, productDal.Object, orderDal.Object);
        shoppingCart.ShoppingCartId = Guid.NewGuid().ToString();
        
        // Assert
        Assert.True(shoppingCart.ClearCart());
    }
    
    [Fact] 
    public void Cart_Could_Not_Be_Cleared_Throws_Exception()
    {
        // Arrange
        var shoppingCartDal = ShoppingCartDALMock.GetShoppingCartDALMock();
        var productDal = ProductDALMock.GetProductDALMock();
        var orderDal = OrderDALMock.GetOrderDALMock();
        shoppingCartDal.Setup(dal=> dal.ClearCart(It.IsAny<string>())).Throws<Exception>();
        
        // Act
        //setup a mock for adding an item to the cart
        var shoppingCart = new ShoppingCart(shoppingCartDal.Object, productDal.Object, orderDal.Object);
        shoppingCart.ShoppingCartId = Guid.NewGuid().ToString();
        
        // Assert
        Assert.ThrowsAny<Exception>(()=>shoppingCart.ClearCart());
    }
    
    
    
    [Fact]
    public void Total_Should_Return_TotalPrice_Of_All_Items_In_Cart()
    {
        // Arrange
        var shoppingCartDal = ShoppingCartDALMock.GetShoppingCartDALMock();
        var productDal = ProductDALMock.GetProductDALMock();
        var orderDal = OrderDALMock.GetOrderDALMock();

        var shoppingCart = new ShoppingCart(shoppingCartDal.Object, productDal.Object, orderDal.Object);
        shoppingCart.ShoppingCartId = Guid.NewGuid().ToString();

        //Act
        shoppingCart.ShoppingCartItems = ShoppingItemCartStub.GetStub();
        var total = shoppingCart.GetShoppingCartTotal();
        
        //Assert
        Assert.Equal(1500, total);
    }
    
    [Fact]
    public void Total_Price_Return_Zero_On_Empty_Cart()
    {
        // Arrange
        var shoppingCartDal = ShoppingCartDALMock.GetShoppingCartDALMock();
        var productDal = ProductDALMock.GetProductDALMock();
        var orderDal = OrderDALMock.GetOrderDALMock();

        var shoppingCart = new ShoppingCart(shoppingCartDal.Object, productDal.Object, orderDal.Object);
        shoppingCart.ShoppingCartId = Guid.NewGuid().ToString();

        //Act
        shoppingCart.ShoppingCartItems = new List<ShoppingCartItem>();
        var total = shoppingCart.GetShoppingCartTotal();
        
        //Assert
        Assert.Equal(0, total);
    }

    [Fact]
    public void Product_Removed_From_Cart()
    {
            // Arrange
        var shoppingCartDal = ShoppingCartDALMock.GetShoppingCartDALMock();
        var productDal = ProductDALMock.GetProductDALMock();
        var orderDal = OrderDALMock.GetOrderDALMock();

        var shoppingCart = new ShoppingCart(shoppingCartDal.Object, productDal.Object, orderDal.Object);
        shoppingCart.ShoppingCartId = Guid.NewGuid().ToString();

        //Act
        shoppingCart.ShoppingCartItems = ShoppingItemCartStub.GetStub();
        var product = new Product()
        {
            ProductId = 1,
            Name = "Test",
            Price = 10,
            Description = "Test",
            ImageLink = "Test",
        };
        
        
        //Assert
        Assert.True(shoppingCart.RemoveFromCart(product));
    }
    
    
    [Fact]
    public void Product_Could_Not_Be_Removed_Returns_False()
    {
        // Arrange
        var shoppingCartDal = ShoppingCartDALMock.GetShoppingCartDALMock();
        var productDal = ProductDALMock.GetProductDALMock();
        var orderDal = OrderDALMock.GetOrderDALMock();

        shoppingCartDal.Setup(dal=> dal.RemoveFromCart(It.IsAny<ShoppingCartItemDto>())).Returns(false);
        var shoppingCart = new ShoppingCart(shoppingCartDal.Object, productDal.Object, orderDal.Object);
        shoppingCart.ShoppingCartId = Guid.NewGuid().ToString();

        //Act
        shoppingCart.ShoppingCartItems = ShoppingItemCartStub.GetStub();
        var product = new Product()
        {
            ProductId = 1,
            Name = "Test",
            Price = 10,
            Description = "Test",
            ImageLink = "Test",
        };
        
        
        //Assert
        Assert.False(shoppingCart.RemoveFromCart(product));
    }
    
      
    [Fact]
    public void Remove_From_Cart_Catches_Exception_And_Throws_Up_Stack_Above()
    {
        // Arrange
        var shoppingCartDal = ShoppingCartDALMock.GetShoppingCartDALMock();
        var productDal = ProductDALMock.GetProductDALMock();
        var orderDal = OrderDALMock.GetOrderDALMock();
        
        shoppingCartDal.Setup(dal=> dal.RemoveFromCart(It.IsAny<ShoppingCartItemDto>())).Throws<Exception>();
        var shoppingCart = new ShoppingCart(shoppingCartDal.Object, productDal.Object, orderDal.Object);
        shoppingCart.ShoppingCartId = Guid.NewGuid().ToString();

        //Act
        shoppingCart.ShoppingCartItems = ShoppingItemCartStub.GetStub();
        var product = new Product()
        {
            ProductId = 1,
            Name = "Test",
            Price = 10,
            Description = "Test",
            ImageLink = "Test",
        };
        
        
        //Assert
        Assert.ThrowsAny<Exception>(()=>shoppingCart.RemoveFromCart(product));
    }
}

