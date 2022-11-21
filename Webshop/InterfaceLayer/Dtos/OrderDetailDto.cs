namespace InterfaceLayer.Dtos;

public class OrderDetailDto
{
    public int OrderDetailId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Amount { get; set; }
    public decimal Price { get; set; }
    public ProductDto Product { get; set; } = default!;
    public OrderDto Order { get; set; } = default!;
}