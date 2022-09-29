using LogicLayer.Models;

namespace LogicLayer.Interfaces;

public interface IProductContainer
{
    /// <summary>
    /// Interface for The Container | Repository class for the products
    /// Used for the Dependency Injection Principle
    /// </summary>
    
    IList<Product> products { get; set; }
    public IList<Product> GetAll();
    public Product GetById(int id);
    public Product GetProduct(int id);
    public IEnumerable<Product> GetSearchedProducts(string filter);
    public string UpdateProduct(Product product); 
    public string Delete(int id); 

}