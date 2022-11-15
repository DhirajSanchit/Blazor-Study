using InterfaceLayer.Dtos;

namespace InterfaceLayer.DALs;

public interface IShoppingCartDAL
{
    void AddToCart(ShoppingCartItemDto dto);

    bool RemoveFromCart(ShoppingCartItemDto dto);

    List<ShoppingCartItemDto> GetShoppingCartItems(string id);

    bool ClearCart(string id);

    List<ShoppingCartItemDto> ShoppingCartItems { get; set; }

    ShoppingCartItemDto? CheckCart(int productId, string cartId);

    public bool InCart(ShoppingCartItemDto dto);
}