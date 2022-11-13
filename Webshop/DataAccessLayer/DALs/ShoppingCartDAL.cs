using InterfaceLayer.DALs;
using InterfaceLayer.Dtos;

namespace DataAccessLayer.DALs;

public class ShoppingCartDAL : IShoppingCartDAL
{
    private readonly IDataAccess _dataAccess;
    public List<ShoppingCartItemDto> ShoppingCartItems { get; set; }

    public ShoppingCartDAL(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public bool InCart(ShoppingCartItemDto dto)
    {
        try
        {
            var result = _dataAccess.QueryFirstOrDefault<ShoppingCartItemDto, dynamic>(
                "SELECT * FROM [ShoppingCartItems] WHERE ShoppingCartId = @ShoppingCartId AND ProductId = @ProductId",
                new { ShoppingCartId = dto.ShoppingCartId, ProductId = dto.ProductId });
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (NullReferenceException nre)
        {
            Console.WriteLine("NullReferenceException:" + nre.Message);
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void AddToCart(ShoppingCartItemDto dto)
    {
        try
        {
            if (!InCart(dto))
            {
                var affectedRows = _dataAccess.ExecuteCommand(
                    "INSERT INTO [ShoppingCartItems] (ShoppingCartId, ProductId, Amount) VALUES (@ShoppingCartId, @ProductId, @Quantity)",
                    new
                    {
                        @ShoppingCartId = dto.@ShoppingCartId, @ProductId = dto.ProductId,
                        @Quantity = dto.Amount
                    });
                Console.WriteLine(affectedRows);
            }
            else
            {
                var affectedRows= _dataAccess.ExecuteCommand(
                    "UPDATE [ShoppingCartItems] SET Amount = Amount + @Quantity WHERE ShoppingCartId = @ShoppingCartId AND ProductId = @ProductId",
                    new
                    {
                        ShoppingCartId = dto.ShoppingCartId, 
                        ProductId = dto.ProductId,
                        Quantity = dto.Amount
                    });
                 
                Console.WriteLine($"{affectedRows} rows affected"); 
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public int RemoveFromCart(ProductDto product)
    {
        throw new NotImplementedException();
    }

    public List<ShoppingCartItemDto> GetShoppingCartItems()
    {
        throw new NotImplementedException();
    }

    public List<ShoppingCartItemDto> GetShoppingCartItems(string id)
    {
        List<ShoppingCartItemDto> dataset;
        dataset = _dataAccess.Query<ShoppingCartItemDto, dynamic>(
            @"SELECT * FROM [ShoppingCartItems] WHERE ShoppingCartId = @ShoppingCartId",
            new { @ShoppingCartId = id });
        return dataset; 
    }

    public void ClearCart()
    {
        throw new NotImplementedException();
    }

    public decimal GetShoppingCartTotal()
    {
        throw new NotImplementedException();
    }

    public void UpdateShoppingCartItemByCartId(ShoppingCartItemDto dto, int Amount)
    {
        throw new NotImplementedException();
        //Implement function to update shopping cart items amount
    }

    public ShoppingCartItemDto? CheckCart(int productId, string cartId)
    {
        try
        {
            return _dataAccess.QueryFirstOrDefault<ShoppingCartItemDto, dynamic>(
                "SELECT * FROM [ShoppingCartItems] WHERE ShoppingCartId = @ShoppingCartId AND ProductId = @ProductId",
                new { @ProductId = productId, @ShoppingCartId = cartId });
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            throw;
        }
    }
}