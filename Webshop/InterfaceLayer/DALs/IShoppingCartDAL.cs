using InterfaceLayer.Dtos;

namespace InterfaceLayer.DALs;

public interface IShoppingCartDAL
{
    void AddToCart(ProductDto product);

    int RemoveFromCart(ProductDto product);

    List<ShoppingCartItemDto> GetShoppingCartItems();

    void ClearCart();

    decimal GetShoppingCartTotal();

    List<ShoppingCartItemDto> ShoppingCartItems { get; set; }
    
}