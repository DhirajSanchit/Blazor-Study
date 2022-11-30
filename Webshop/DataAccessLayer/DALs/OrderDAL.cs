using InterfaceLayer.DALs;
using InterfaceLayer.Dtos;

namespace DataAccessLayer.DALs;

public class OrderDAL : IOrderDAL
{
    private readonly IDataAccess _dataAccess;

    public OrderDAL(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    //TODO: Looks Messy, refactor later
    public int CreateOrder(OrderDto orderDto)
    {
        try
        {
            //Create an sql query to insert the order into the database
            string orderSql =
                @"Insert into [Orders] (FirstName, LastName, AddressLine1, AddressLine2, ZipCode, City, Country, PhoneNumber, Email, OrderTotal, OrderPlaced) 
                                values (@FirstName, @LastName, @AddressLine1, @AddressLine2, @ZipCode, @City, @Country, @PhoneNumber, @Email, @OrderTotal, @OrderPlaced);
                                SELECT CAST(SCOPE_IDENTITY() as int)";


            var orderId = _dataAccess.QueryFirstOrDefault<int, dynamic>(orderSql, orderDto);

            int detailrows = 0;
            if (orderDto.OrderDetails != null)
                foreach (var item in orderDto.OrderDetails)
                {
                    var orderDetailSql = @"INSERT INTO [OrderDetails] (OrderId, ProductId, Amount, Price) 
                                        VALUES (@OrderId, @ProductId, @Quantity, @UnitPrice)";

                    detailrows += _dataAccess.ExecuteCommand(orderDetailSql,
                        new
                        {
                            OrderId = orderId, item.ProductId, @Quantity = item.Amount,
                            UnitPrice = item.Price
                        });
                }

            Console.WriteLine($"Order created with {orderId} and {detailrows} detail rows");
            return detailrows;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Source}, {ex.Message}");
            throw ex;
        }
    }

    public List<OrderDto> GetAllOrders()
    {
        throw new NotImplementedException();
    }
}