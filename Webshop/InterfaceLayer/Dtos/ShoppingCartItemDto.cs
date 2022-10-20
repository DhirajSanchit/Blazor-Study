namespace InterfaceLayer.Dtos;

public record ShoppingCartItemDto
{
    public int ShoppingCartItemId { get; init; }
    public ProductDto ProductDto { get; init; }  
    public int Amount { get; init; }
    public string? ShoppingCartId { get; init; }
}