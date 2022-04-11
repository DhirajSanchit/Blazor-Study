using LogicLayer.Models;

namespace LogicLayer.Interfaces;

public interface IProductContainer
{
    /// <summary>
    /// Interface for The Container | Repository class for the Products
    /// Used for the Dependency Injection Principle
    /// </summary>
    
    IList<Product> Products { get; set; }
    public IList<Product> GetAll();
    public Product GetByID(int id);
}