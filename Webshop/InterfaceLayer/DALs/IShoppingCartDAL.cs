using InterfaceLayer.Dtos;

namespace InterfaceLayer.DALs;

public interface IShoppingCartDAL
{
    void AddToCart(ShoppingCartItemDto product);

    int RemoveFromCart(ProductDto product);

    List<ShoppingCartItemDto> GetShoppingCartItems();
    List<ShoppingCartItemDto> GetShoppingCartItems(string id);

    void ClearCart();

    decimal GetShoppingCartTotal();

    List<ShoppingCartItemDto> ShoppingCartItems { get; set; }
    
    void UpdateShoppingCartItemByCartId(ShoppingCartItemDto dto, int quantity);
    
    ShoppingCartItemDto? CheckCart(int productId, string cartId);

    public bool InCart(ShoppingCartItemDto dto);
}