using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InterfaceLayer.Dtos;

namespace BusinessLogicLayer.Classes;

public class SampleModel
{
    public int Id { get; set; }

    // [StringLength(60, MinimumLength = 3)]
    // [Required]
    // public string? Title { get; set; }
    //
    // [Display(Name = "Release Date")]
    // [DataType(DataType.Date)]
    // public DateTime ReleaseDate { get; set; }
    //
    // [Range(1, 100)]
    // [DataType(DataType.Currency)]
    // [Column(TypeName = "decimal(18, 2)")]
    // public decimal Price { get; set; }
    //
    // [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    // [Required]
    // [StringLength(30)]
    // public string? Genre { get; set; }
    //
    // [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    // [StringLength(5)]
    // [Required]
    // public string? Rating { get; set; }

    public string Value { get; set; }

    public SampleModel(SampleDto dto)
    {
        Id = dto.Id;
        Value = dto.Value;
    }

    public SampleModel(int id, string value)
    {
        Id = id;
        Value = value;
    }

    public SampleModel()
    {
        
    }
}