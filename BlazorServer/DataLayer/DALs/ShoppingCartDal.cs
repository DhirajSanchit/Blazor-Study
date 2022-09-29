using System.Data;
using Dapper;
using DataLayer.Dtos;
using DataLayer.Interfaces;

namespace DataLayer.DALs;

public class  vShoppingCartDal : IShoppingCartDal
{
    private readonly IDbConnection _dbConnection;

    // public ShoppingCartDal(IDbConnection dbConnection)
    // {
    //     _dbConnection = dbConnection;
    // }
    public IList<ShoppingCartDto> GetAll()
    {
        
        var sql = @"select ProductId, Name, Price, [Product].Description as Description, C.Description as Category
                        from  Product
                        LEFT JOIN dbo.Category C on C.CategoryId = Product.CategoryId";
        try
        {

            using (_dbConnection)
            {
                // var tests = (IList<TestDto>) await _dbConnection.QueryAsync("sql");
                var dataset = _dbConnection.Query<ShoppingCartDto>(sql).ToList();
                return dataset;
            }
        }
        catch (Exception ex)
        {   

            Console.WriteLine(ex.Message);
            throw new Exception(ex.Message);
        }

        finally
        {
            _dbConnection.Close();
        }
    }

    
    //TODO: To be implemented when Users and Sessions realized; Out of scope for now.
    public ShoppingCartDto GetById(int id)
    {
        throw new NotImplementedException();
    }

    
    
    public ShoppingCartDto AddItem()
    {
        throw new NotImplementedException();
    }
} 