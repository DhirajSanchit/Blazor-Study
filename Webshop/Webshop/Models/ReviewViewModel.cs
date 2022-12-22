namespace Webshop.Models;

public class ReviewViewModel
{
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public string Description { get; set; }
    public int ReviewId { get; set; }
    public int ReviewerId { get; set; }
}