using InterfaceLayer.DALs;
using InterfaceLayer.Dtos;

namespace DataAcessLayer.DALs;

public class ShoppingCartDAL : IShoppingCartDAL
{
    private readonly IDataAccess _dataAccess;

    public ShoppingCartDAL(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public void AddToCart(ProductDto product)
    {
        throw new NotImplementedException();
    }

    public int RemoveFromCart(ProductDto product)
    {
        throw new NotImplementedException();
    }

    public List<ShoppingCartItemDto> GetShoppingCartItems()
    {
        throw new NotImplementedException();
    }

    public void ClearCart()
    {
        throw new NotImplementedException();
    }

    public decimal GetShoppingCartTotal()
    {
        throw new NotImplementedException();
    }

    public List<ShoppingCartItemDto> ShoppingCartItems { get; set; }
}