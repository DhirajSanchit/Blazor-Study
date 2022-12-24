using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.Classes; 

namespace Webshop.Models;

public class ProductViewModel
{
    public int Id { get; set; }
    
    [StringLength(50, MinimumLength = 5)]
    [Required]
    public string Name { get; set; }
    
    [Range(0.01, 100.00, ErrorMessage = "Price must be between 0.01 and 100.00")]
    [DataType(DataType.Currency)]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Required]
    public decimal Price { get; set; }

    [StringLength(100, MinimumLength = 10)]
    [Required]
    public string Description { get; set; }
    
    // [StringLength(255)]
    // [Required]
    public string ImageLink { get; set; }
    
    public DateTime? ArchiveDate { get; set; }
 
    public IEnumerable<Product>? _Products { get; set; }
    
    //TODO:
    //Update viewmodel to contain userreviews
    //Update ViewModel to contain correct images
    
}
