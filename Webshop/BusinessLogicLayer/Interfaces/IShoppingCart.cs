using BusinessLogicLayer.Classes;
namespace BusinessLogicLayer.Interfaces;

public interface IShoppingCart
{
    bool AddToCart(Product product);

    bool RemoveFromCart(Product product);

    List<ShoppingCartItem> GetShoppingCartItems();

    bool ClearCart();

    decimal GetShoppingCartTotal();

    List<ShoppingCartItem> ShoppingCartItems { get; set; }
}

 