namespace BusinessLogicLayer.Classes
{
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

        
        // Code Below is used for further implementation when layer structure has been optimized
        // public ProductDto ToDto()
        // {
        //     return null;
        // }
        public Product(int productId, string brand, string name, double price, string imageLink, string description)
        {
            ProductId = productId;
            Brand = brand;
            Name = name;
            Price = price;
            ImageLink = imageLink;
            Description = description;
        }
    }
}
