using BusinessLogicLayer.Classes;
namespace BusinessLogicLayer.Interfaces;

public interface IShoppingCart
{
    void AddToCart(Product product);

    bool RemoveFromCart(Product product);

    List<ShoppingCartItem> GetShoppingCartItems();

    // void ClearCart();

    decimal GetShoppingCartTotal();

    List<ShoppingCartItem> ShoppingCartItems { get; set; }
}

 