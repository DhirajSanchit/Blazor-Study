using InterfaceLayer.DALs;
using InterfaceLayer.Dtos;

namespace WebshopTests.Mocks.DALs;

public class OrderDALMock
{
    public static Mock<IOrderDAL> GetOrderDALMock()
    {

        #region Stub of OrderDtos and Items
        
        var stub = new List<OrderDto>()
        {
            new OrderDto()
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
                OrderDetails = new List<OrderDetailDto>()
                {
                    new OrderDetailDto()
                    {
                        OrderDetailId = 1,
                        OrderId = 1,
                        ProductId = 1,
                        Amount = 1,
                        Price = 100
                    },
                    new OrderDetailDto()
                    {
                        OrderDetailId = 2,
                        OrderId = 1,
                        ProductId = 2,
                        Amount = 1,
                        Price = 100
                    },
                    new OrderDetailDto()
                    {
                        OrderDetailId = 3,
                        OrderId = 1,
                        ProductId = 3,
                        Amount = 1,
                        Price = 100
                    }
                },
            },
            new OrderDto()
            {
                OrderId = 2,
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
                Email = "nothingtoseehere@gmail.com",
                OrderDetails = new List<OrderDetailDto>()
                {
                    new OrderDetailDto()
                    {
                        OrderDetailId = 4,
                        OrderId = 2,
                        ProductId = 1,
                        Amount = 1,
                        Price = 100
                    },
                    new OrderDetailDto()
                    {
                        OrderDetailId = 5,
                        OrderId = 2,
                        ProductId = 2,
                        Amount = 1,
                        Price = 100
                    },
                    new OrderDetailDto()
                    {
                        OrderDetailId = 6,
                        OrderId = 2,
                        ProductId = 3,
                        Amount = 1,
                        Price = 100
                    }
                }
            }
        };
        
        #endregion
        
        
        var orderDALMock = new Mock<IOrderDAL>();
        //Setup a method that returns a list of orders
        orderDALMock.Setup(dal => dal.GetAllOrders()).Returns(stub);
        return orderDALMock;
    }
}