using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Containers;
using InterfaceLayer.Dtos;
using WebshopTests.Mocks.Containers;
using WebshopTests.Mocks.DALs;
using WebshopTests.Stub;

namespace WebshopTests.Containers;

public class OrderContainerTests
{
    #region Order object Used for Tests, cleans up test methods
    Order order = new Order()
    {
        OrderId = 1,
        OrderPlaced = DateTime.Now,
        OrderTotal = 100,
        FirstName = "John",
        LastName = "Doe",
        AddressLine1 = "123 Main St",
        AddressLine2 = "Apt 1",
        City = "Seattle",
        State = "WA",
        ZipCode = "12345",
        Country = "USA",
        PhoneNumber = "123-456-7890",
        Email = "Example@gmail.com",
    };
    
    #endregion

    [Fact]
    private void Create_WithValidData_ShouldCreateOrder()
    {
        // Arrange
        var orderDalMock = OrderDALMock.GetOrderDALMock();
        var shoppingCartMock = ShoppingCartMock.GetShoppingCartMock();

        shoppingCartMock.Setup(cart => cart.ShoppingCartItems).Returns(ShoppingItemCartStub.GetStub());
        orderDalMock.Setup(dal => dal.CreateOrder(It.IsAny<OrderDto>())).Returns(1);

        //Set up the shopping cart mock to a list of shopping cart items
        var cartInstance = shoppingCartMock.Object;
        var OrderDalInstance = orderDalMock.Object;

        var orderContainer = new OrderContainer(cartInstance, OrderDalInstance);

        // Act
        // var order = new Order()
        // {
        //     OrderId = 1,
        //     OrderPlaced = DateTime.Now,
        //     OrderTotal = 100,
        //     FirstName = "John",
        //     LastName = "Doe",
        //     AddressLine1 = "123 Main St",
        //     AddressLine2 = "Apt 1",
        //     City = "Seattle",
        //     State = "WA",
        //     ZipCode = "12345",
        //     Country = "USA",
        //     PhoneNumber = "123-456-7890",
        //     Email = "Example@gmail.com",
        //     OrderDetails = new List<OrderDetail>()
        // };
        order.OrderDetails = new List<OrderDetail>();

        var result = orderContainer.CreateOrder(order);

        // Assert if the order was added to the list and matches the order we created;
        Assert.True(result);
    }


    [Fact]
    public void Creating_Order_With_No_ShoppingCartItems_Throws_Exception()
    {
        // Arrange
        var orderDalMock = OrderDALMock.GetOrderDALMock();
        var shoppingCartMock = ShoppingCartMock.GetShoppingCartMock();


        orderDalMock.Setup(dal => dal.CreateOrder(It.IsAny<OrderDto>())).Returns(1);

        //Set up the shopping cart mock to a list of shopping cart items
        var cartInstance = shoppingCartMock.Object;
        var OrderDalInstance = orderDalMock.Object;

        var orderContainer = new OrderContainer(cartInstance, OrderDalInstance);

        // Act
        //

        Assert.ThrowsAny<Exception>(() => orderContainer.CreateOrder(order));
    }

    [Fact]
    public void Return_False_If_No_Rows_Were_Affected()
    {
        // Arrange
        var orderDalMock = OrderDALMock.GetOrderDALMock();
        var shoppingCartMock = ShoppingCartMock.GetShoppingCartMock();

        shoppingCartMock.Setup(cart => cart.ShoppingCartItems).Returns(ShoppingItemCartStub.GetStub());
        orderDalMock.Setup(dal => dal.CreateOrder(It.IsAny<OrderDto>())).Returns(0);

        //Set up the shopping cart mock to a list of shopping cart items
        var cartInstance = shoppingCartMock.Object;
        var OrderDalInstance = orderDalMock.Object;

        var orderContainer = new OrderContainer(cartInstance, OrderDalInstance);

        // Act
        order.OrderDetails = new List<OrderDetail>();
        Assert.False(orderContainer.CreateOrder(order));
    }
}