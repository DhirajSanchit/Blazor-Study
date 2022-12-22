using System.ComponentModel.DataAnnotations;

namespace Webshop.Models;

public class AssortmentViewModel
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
    
    public string ImageLink { get; set; }
    
    public DateTime? ArchiveDate { get; set; }

    public string BorderLayout { get; set; }
    public string TextLayout { get; set; }
}