using BusinessLogicLayer.Containers;
using BusinessLogicLayer.Interfaces;

namespace WebshopTests.Mocks.Containers;

public class ShoppingCartMock
{
    public static Mock<IShoppingCart> GetShoppingCartMock()
    {
        var shoppingCartMock = new Mock<IShoppingCart>();

        return shoppingCartMock;
    }
}