namespace DataLayer.Dtos;

public class ProductDto
{
    public int ProductId { get; set; }
    public string Name;
    public float Price;
    public string Description { get; set; }
    public int CategoryId;
    public string Category;
    public string Brand;
    public string ImageLink { get; set; }
}