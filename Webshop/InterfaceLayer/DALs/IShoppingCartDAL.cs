using InterfaceLayer.Dtos;

namespace InterfaceLayer.DALs;

public interface IShoppingCartDAL
{
    void AddToCart(ShoppingCartItemDto dto);

    bool RemoveFromCart(ShoppingCartItemDto dto);

    List<ShoppingCartItemDto> GetShoppingCartItems();
    List<ShoppingCartItemDto> GetShoppingCartItems(string id);

    void ClearCart();

    List<ShoppingCartItemDto> ShoppingCartItems { get; set; }
    
    void UpdateShoppingCartItemByCartId(ShoppingCartItemDto dto, int quantity);
    
    ShoppingCartItemDto? CheckCart(int productId, string cartId);

    public bool InCart(ShoppingCartItemDto dto);
}