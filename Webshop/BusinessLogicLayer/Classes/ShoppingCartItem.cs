using InterfaceLayer.Dtos;

namespace BusinessLogicLayer.Classes;

public class ShoppingCartItem
{
    public int ShoppingCartItemId { get; set; }
    public Product Product { get; set; }
    public int Amount { get; set; }
    public string? ShoppingCartId { get; set; }

    protected internal ShoppingCartItemDto toDto()
    {
        return new ShoppingCartItemDto
        {
            ShoppingCartItemId = ShoppingCartItemId,
            ProductId = Product.ProductId,
            Amount = Amount,
            ShoppingCartId = ShoppingCartId
        };
    }
    
    protected internal ShoppingCartItem(ShoppingCartItemDto dto)
    {
        ShoppingCartItemId = dto.ShoppingCartItemId;
        Amount = dto.Amount;
        ShoppingCartId = dto.ShoppingCartId;
    }
    
    protected internal ShoppingCartItem(ShoppingCartItemDto dto, Product product)
    {
        ShoppingCartItemId = dto.ShoppingCartItemId;
        Product = product;
        Amount = dto.Amount;
        ShoppingCartId = dto.ShoppingCartId;
    }
    
    public ShoppingCartItem()
    {
        
    }
    
}