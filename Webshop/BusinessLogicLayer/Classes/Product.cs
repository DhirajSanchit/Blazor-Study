using InterfaceLayer.Dtos;

namespace BusinessLogicLayer.Classes;

public class Product
{
    public int ProductId { get; set; }
    public string Brand { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string ImageLink { get; set; }
    public string Description { get; set; }

    public Product()
    {
        
    }
    
    public Product(InterfaceLayer.Dtos.ProductDto dto)
    {
        ProductId = dto.ProductId;
        Brand = dto.Brand;
        Name = dto.Name;
        Price = dto.Price;
        ImageLink = dto.ImageLink;
        Description = dto.Description;
    }
    
    //Converts a Product to a ProductDto
     ProductDto ToDto()
    {
        return new ProductDto
        {
            ProductId = ProductId,
            Brand = Brand,
            Name = Name,
            Price = Price,
            ImageLink = ImageLink,
            Description = Description
        };
    }
    
    
}