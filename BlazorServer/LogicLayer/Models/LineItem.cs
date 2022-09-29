namespace LogicLayer.Models;

public class LineItem
{
    public int? LineItemId { get; set; }
    public int ProductId { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public int? OrderId { get; set; }
    public Product Product { get; set; }
    
    public LineItem()
    {
        
    }
}   