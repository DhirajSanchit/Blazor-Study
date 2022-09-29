using System.Data;
using DataLayer.Dtos;
using DataLayer.Interfaces;

namespace DataLayer.DALs;

public class OrderDal : IOrderDal
{
    private readonly IDataAccess _dataAccess;
    private readonly IDbConnection _dbConnection;

    public OrderDal(IDataAccess dataAccess, IDbConnection dbConnection)
    {
        _dataAccess = dataAccess;
        _dbConnection = dbConnection;
    }
    
    public IList<LineItemDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public LineItemDto GetById(int id)
    {
        throw new NotImplementedException();
    }

    public LineItemDto SaveProduct(int id)
    {
        throw new NotImplementedException();
    }

    public LineItemDto DeleteOrder(int id)
    {
        throw new NotImplementedException();
    }
}