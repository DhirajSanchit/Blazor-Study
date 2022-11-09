using InterfaceLayer.Dtos;

namespace BusinessLogicLayer.Classes;

public class ShoppingCartItem
{
    public int ShoppingCartItemId { get; set; }
    public Product Product { get; set; } = default!;
    public int Amount { get; set; }
    public string? ShoppingCartId { get; set; }

    protected internal ShoppingCartItemDto toDto()
    {
        return new ShoppingCartItemDto
        {
            ShoppingCartItemId = ShoppingCartItemId,
            ProductDto = Product.toDto(),
            Amount = Amount,
            ShoppingCartId = ShoppingCartId
        };
    }

    protected internal ShoppingCartItem(ShoppingCartItemDto dto)
    {
        ShoppingCartItemId = dto.ShoppingCartItemId;
        Product = new Product(dto.ProductDto);
        Amount = dto.Amount;
        ShoppingCartId = dto.ShoppingCartId;
    }

    public ShoppingCartItem()
    {
        
    }
    
}