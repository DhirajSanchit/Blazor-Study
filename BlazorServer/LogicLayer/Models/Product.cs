using DataLayer.Dtos;

namespace LogicLayer.Models;

public class Product
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public int CategoryId { get; set; }
    public string Category { get; set; }
 
    public Product(ProductDto dto)
    {
        Id = dto.Id;
        Name = dto.Name;
        Price = dto.Price;
        CategoryId = dto.CategoryId;
        Category = dto.Category;
    }
}