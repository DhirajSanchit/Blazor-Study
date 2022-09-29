using DataLayer.Dtos;
using DataLayer.Interfaces;
using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace LogicLayer.Containers;

public class ProductContainer : IProductContainer
{
    private bool _result;
    private string  _message;
    
    private  IProductDal _dal;

    public IList<Product> products { get; set; }
    public Product product;

    public ProductContainer(IProductDal dal)
    {
        _dal = dal;
    }
    
    public IList<Product> GetAll()
    {
        try
        {
            products = new List<Product>();
            IList<ProductDto> dataset = _dal.GetAll();
            foreach (ProductDto dto in dataset)
            {
                products.Add(new Product(dto));
            }

            return products;
        }
        
        //TODO: Split in speccific exception types, closing with 'Exception e'
        catch(Exception e)
        {
            //Give back an empty list for debug purposes
            //IList<Product> empty = new List<Product>();
            
            //TODO: revise this ugly and dumb way to retrieve an error message;
            Product test = new();
            test.Name = e.Message;
            products.Add(test);
            return products;
            
        }
    }

    public Product GetById(int id)
    {
        //return product = _context.GetById(id);
        return null;
    }

    public Product GetProduct(int id)
    {
        try
        {
            ProductDto dto = _dal.GetById(id);
            if (dto != null)
            {

                return new Product(dto);
                //return product = _context.GetById(id);
                //return products.FirstOrDefault(x => x.Id == id);
                return null;
            }
            else
            {
                return new Product();
            }
        }
        catch (NullReferenceException nre)
        {
            throw new Exception("Something went wrong", nre);
        }
        catch (Exception ex)
        {
            throw new Exception("Something went wrong", ex);
        }
    }


    public IEnumerable<Product> GetSearchedProducts(string filter = null)
    {
        
        if (string.IsNullOrWhiteSpace(filter))
        {
            return products;
        }
        return products.Where(x=>x.Name.ToLower().Contains(filter.ToLower()));
    }

    public string UpdateProduct(Product product)
    {
        try
        {
            _result = _dal.UpdateProduct(product.ToDto());
            if (_result)
            {
                _message = "Succes!";
            }
            else
            {
                _message = "Something went wrong";
            }
        }
        catch (InvalidOperationException invalidOperationException)
        {
            throw new InvalidOperationException("Something went wrong", invalidOperationException);
        }
        catch (ArgumentException argumentException)
        {
            throw new ArgumentException("Something went wrong", argumentException);

        }
        catch (Exception e)
        {
            throw;
        }
        return _message;
    }

    public string Delete(int id)
    {
        try
        {
            _result = _dal.DeleteProduct(product.ProductId);
            if (_result)
            {
                _message = "Succes!";
            }
            else
            {
                _message = "Something went wrong";
            }
        }
        catch (InvalidOperationException invalidOperationException)
        {
            throw new InvalidOperationException("Something went wrong", invalidOperationException);
        }
        catch (ArgumentException argumentException)
        {
            throw new ArgumentException("Something went wrong", argumentException);

        }
        catch (Exception e)
        {
            throw;
        }

        return _message;
    }
}
