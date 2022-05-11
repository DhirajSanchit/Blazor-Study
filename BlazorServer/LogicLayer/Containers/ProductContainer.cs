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
    public Product product;

    public ProductContainer(IProductDal context)
    {
        _context = context;
    }
    
    public IList<Product> GetAll()
    {
        try
        {
            Products = new List<Product>();
            IList<ProductDto> dataset = _context.GetAll();
            foreach (ProductDto dto in dataset)
            {
                Products.Add(new Product(dto));
            }

            return Products;
        }
        
        //TODO: Split in speccific exception types, closing with 'Exception e'
        catch(Exception e)
        {
            //Give back an empty list for debug purposes
            IList<Product> empty = new List<Product>();
            return Products = empty;
        }
    }

    public Product GetByID(int id)
    {
        //return product = _context.GetById(id);
        return null;
    }
}