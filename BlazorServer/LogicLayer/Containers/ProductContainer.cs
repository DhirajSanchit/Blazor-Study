using System.Diagnostics.CodeAnalysis;
using DataLayer.Dtos;
using DataLayer.Interfaces;
using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace LogicLayer.Containers;

public class ProductContainer : IProductContainer
{
    /// <summary>
    /// Container | 
    /// </summary>
    
    private  IProductDal _context;
    public IList<Product> Products { get; set; }

    public ProductContainer(IProductDal context)
    {
        _context = context;
    }
    
    public IList<Product> GetAll()
    {
        Products = new List<Product>();
        IList<ProductDto> dataset = _context.GetAll();
        foreach (ProductDto dto in dataset)
        {
            Products.Add(new Product(dto));
        }

        return Products;
    }
}