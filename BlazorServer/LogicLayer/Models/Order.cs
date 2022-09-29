namespace LogicLayer.Models;

public class Order
{
    public Order()
    {
        LineItems = new();
    }

    public int? OrderId { get; set; }
    public DateTime? DatePlaced { get; set; }
    public DateTime? DateProcessing { get; set; }
    public DateTime? DateProcessed { get; set; }
    public string CustomerName { get; set; }
    public string CustomerAddress { get; set; }
    public string CustomerCity { get; set; }
    public string CustomerProvince { get; set; }
    public string CustomerCountry  { get; set; }
    public string AdminUser { get; set; }
    public List<LineItem> LineItems { get; set; }
    public string UniqueId { get; set; }
    
    //AddProduct
    public void AddProduct(int productId, int quantity, double price)
    {
        var item = LineItems.FirstOrDefault(product => product.ProductId == productId);
        if (item != null)
        {
            item.Quantity += quantity;
        }
        else
        {
            LineItems.Add(new LineItem{ProductId = productId, Quantity = quantity, Price = price});
        }
    }
    
    //Remove Product 
    public void RemoveProduct(int productId)
    {
        var item = LineItems.FirstOrDefault(product => product.ProductId == productId);
        if (item != null)
        {
            LineItems.Remove(item);
        }
    }
}
 