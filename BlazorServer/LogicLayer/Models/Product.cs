using DataLayer.Dtos;

namespace LogicLayer.Models;

public class Product
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public int CategoryId { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
 
    public Product(ProductDto dto)
    {
        Id = dto.ProductId;
        Name = dto.Name;
        Price = dto.Price;
        Description = dto.Description;
        CategoryId = dto.CategoryId;
        Category = dto.Category;
    }
}