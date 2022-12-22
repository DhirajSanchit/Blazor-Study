using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.Classes; 

namespace Webshop.Models;

public class ProductViewModel
{
    public int Id { get; set; }
    
    [StringLength(50, MinimumLength = 5)]
    [Required]
    public string Name { get; set; }
    
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
    
    public DateTime? ArchiveDate { get; set; }
    
    
    
    public Product? Product;
    public IEnumerable<Product>? _Products { get; set; }
    
    //TODO:
    //Update viewmodel to contain userreviews
    //Update ViewModel to contain correct images
    
}
