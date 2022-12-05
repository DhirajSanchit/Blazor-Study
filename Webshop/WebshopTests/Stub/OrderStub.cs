using BusinessLogicLayer.Classes;

namespace WebshopTests.Stub;

public class OrderStub
{
    
    #region Stub for for single Order
    public static Order GetOrder()
    {
       

        var order = new Order()
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

        return order;
    }
    #endregion
}

