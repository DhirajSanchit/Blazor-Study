using System.ComponentModel.DataAnnotations;
using InterfaceLayer.Dtos;

namespace BusinessLogicLayer.Classes;

public class Product
{
    public int ProductId { get; set; }
    
    [StringLength(50, MinimumLength = 5)]
    [Required]
    public string Name { get; set; }
    
    // public string Brand { get; set; }
    
    [Range(1, 100)]
    [DataType(DataType.Currency)]
    [Required]
    public decimal Price { get; set; }
    
    
    [StringLength(100, MinimumLength = 10)]
    [Required]
    public string Description { get; set; }
    
    // [StringLength(255)]
    // [Required]
    public string ImageLink { get; set; }

    public Product()
    {
        
    }
    
    protected internal Product(ProductDto dto)
    {
        ProductId = dto.ProductId;
        // Brand = dto.Brand;
        Name = dto.Name;
        Price = dto.Price;
        ImageLink = dto.ImageLink;
        Description = dto.Description;
    }
    
    //Converts a Product to a ProductDto

    protected internal ProductDto toDto()
    {
        return new ProductDto
        {
            ProductId = this.ProductId,
            // Brand = Brand,
            Name = this.Name,
            Price = this.Price,
            ImageLink = this.ImageLink,
            Description = this.Description
        };
    }
    
    
}