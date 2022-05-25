using LogicLayer.Models;

namespace LogicLayer.Interfaces;

public interface ISearchProduct
{
    public IEnumerable<Product> Execute(string filter = null);

}