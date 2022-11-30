using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Containers;
using BusinessLogicLayer.Interfaces;
using InterfaceLayer.Dtos;
using WebshopTests.Mocks.Containers;
using WebshopTests.Mocks.DALs;
using WebshopTests.Stub;

namespace WebshopTests.Containers;

public class ShoppingCartTests
{

    #region Test, will be reviewed and changed
    public void AddItemToCart()
    {
        // Arrange
        var shoppingCartDal = ShoppingCartDALMock.GetShoppingCartDALMock();
        var productDal = ProductDALMock.GetProductDALMock();
        var orderDal = OrderDALMock.GetOrderDALMock();

        //setup a mock for adding an item to the cart
        shoppingCartDal.Verify(x => x.AddToCart(It.IsAny<ShoppingCartItemDto>()));

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
        
        shoppingCart.AddToCart(product);


        // Assert
       // Assert.Thr
    }
    
    #endregion

    
    [Fact]
    public void Total_ShouldReturnTotalPriceOfAllItemsInCart()
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
        Assert.Equal((decimal)1500, (decimal)total);
    }
}

