namespace DataLayer.Dtos;

public class ProductDto
{
    public int ProductId { get; set; }
    public string Name { get; set; } 
    public double Price { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; } 
    public string Category { get; set; }
    public string Brand { get; set; }
    public string ImageLink { get; set; }
}