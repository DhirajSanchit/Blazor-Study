using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Containers;

namespace WebshopTests.Stub;

public class ShoppingItemCartStub
{
    public static List<ShoppingCartItem> GetStub()
    {
        #region Stub for ShoppingCart Tests using ShoppingCartItems

        var stubData = new List<ShoppingCartItem>()
        {
            new ShoppingCartItem
            {
                ShoppingCartItemId = 1,
                ShoppingCartId = new Guid("00000000-0000-0000-0000-000000000002").ToString(),
                Product = new Product
                {
                    ProductId = 1,
                    Name = "TestProduct1",
                    Price = 100,
                    Description = "TestDescription1",
                    ImageLink = "TestImage1"
                },
                Amount = 2
            },
            new ShoppingCartItem
            {
                Product = new Product
                {
                    ProductId = 2,
                    Name = "TestProduct2",
                    Price = 200,
                    Description = "TestDescription2",
                    ImageLink = "TestImage2"
                },
                Amount = 2
            },
            new ShoppingCartItem
            {
                Product = new Product
                {
                    ProductId = 3,
                    Name = "TestProduct3",
                    Price = 300,
                    Description = "TestDescription3",
                    ImageLink = "TestImage3"
                },
                Amount = 3
            }
        };
        return stubData;

        #endregion
    }
}