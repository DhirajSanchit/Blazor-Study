using InterfaceLayer.DALs;
using InterfaceLayer.Dtos;

namespace WebshopTests.Mocks.DALs;

public class ShoppingCartDALMock
{
    public static Mock<IShoppingCartDAL> GetShoppingCartDALMock()
    {

        #region Stub for ShoppingCartItem Dtos
        
        var shoppingCartDTOs = new List<ShoppingCartItemDto>()
        {
            new ShoppingCartItemDto()
            {
                ShoppingCartItemId = 1,
                ProductId = 1,
                Amount = 1,
                ShoppingCartId = new Guid("00000000-0000-0000-0000-000000000001").ToString()
            },
            new ShoppingCartItemDto()
            {
                ShoppingCartItemId = 2,
                ProductId = 2,
                Amount = 2,
                ShoppingCartId = new Guid("00000000-0000-0000-0000-000000000001").ToString()
            },
            new ShoppingCartItemDto()
            {
                ShoppingCartItemId = 3,
                ProductId = 3,
                Amount = 3,
                ShoppingCartId = new Guid("00000000-0000-0000-0000-000000000001").ToString()
            },
            new ShoppingCartItemDto()
            {
                ShoppingCartItemId = 4,
                ProductId = 4,
                Amount = 4,
                ShoppingCartId = new Guid("00000000-0000-0000-0000-000000000002").ToString()
            },
            new ShoppingCartItemDto()
            {
                ShoppingCartItemId = 5,
                ProductId = 5,
                Amount = 5,
                ShoppingCartId = new Guid("00000000-0000-0000-0000-000000000002").ToString()
            },
        };

        #endregion
        
        
        var shoppingCartDALMock = new Mock<IShoppingCartDAL>();
        // shoppingCartDALMock.Setup(x => x.AddProduct(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
        // shoppingCartDALMock.Setup(x => x.RemoveProduct(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
        // shoppingCartDALMock.Setup(x => x.GetProducts(It.IsAny<int>())).Returns(new List<Product>());
        return shoppingCartDALMock;
    } 
}