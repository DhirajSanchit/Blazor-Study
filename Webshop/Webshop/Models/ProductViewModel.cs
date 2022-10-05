using InterfaceLayer.Dtos;

namespace Webshop.Models;

public class ProductViewModel
{
    public ProductDto Dto;
    public IEnumerable<ProductDto> _products { get; set; }
}