using DataLayer.Dtos;

namespace LogicLayer.Models;

public class Product
{
    
    public int ProductId { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public int CategoryId { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public string Brand { get; set; }
    public string ImageLink { get; set; }

    public Product()
    {
        
    }
 
    public Product(ProductDto dto)
    {
        ProductId = dto.ProductId;
        Name = dto.Name;
        Price = (float)dto.Price;
        Description = dto.Description;
        CategoryId = dto.CategoryId;
        Category = dto.Category;
        Brand = dto.Brand;
        ImageLink = dto.ImageLink;
    }

    public ProductDto ToDto()
    {
        var dto = new ProductDto();
        {
            dto.Name = Name;
            dto.Price = Price;
            dto.CategoryId = CategoryId;
            dto.Description = Description;
            dto.Brand = Brand;
            dto.ImageLink = ImageLink;
        }
        return dto;
    }
}