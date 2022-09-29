namespace BlazorServer.Snippets;

using LogicLayer.Interfaces;
using LogicLayer.Models;
 
public class OrderContainerSnippet : IOrderContainer
{
    private IList<Order> orders;
    private IList<LineItem> LineItems;
    
    public OrderContainerSnippet()
    {
        
    }
    
    public Order CreateNewOrder(Order order)
    {
        try
        {

        }
        catch
        {
         
            throw new NotImplementedException();   
        }

        return null;
    }

    public Order GetOrder(int OrderId)
    {
        //GetByID;
        return null;
    }

    public Order GetOrderId(string uniqueId)
    {
        try
        {

        }
        catch
        {
         
            throw new NotImplementedException();   
        }

        return null;
    }

    public int CreateOrder(Order order)
    {
        try
        {

        }
        catch
        {
         
            throw new NotImplementedException();   
        }

        return 0;
    }

    public void UpdateOrder(Order order)
    {
        try
        {

        }
        catch
        {
         
            throw new NotImplementedException();   
        }

        
        
    }

    public IEnumerable<Order> GetOrders()
    {
        //GetAll via Dal
        return orders;
    }

    public IEnumerable<Order> GetOutstandingOrders()
    {
        try
        {

        }
        catch
        {
         
            throw new NotImplementedException();   
        }

        return null;    }

    public IEnumerable<Order> GetProcessedOrders()
    {
        try
        {

        }
        catch
        {
         
            throw new NotImplementedException();   
        }

        return null;    }

    public IEnumerable<LineItem> GetLineItemsByOrderId(int id)
    {
        try
        {

        }
        catch
        {
         
            throw new NotImplementedException();   
        }

        return null;    }

    public Order GetOrderByUniqueId(string uniqueId)
    {
        try
        {

        }
        catch
        {
         
            throw new NotImplementedException();   
        }

        return null;
    }
}