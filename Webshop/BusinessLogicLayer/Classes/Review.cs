namespace BusinessLogicLayer.Classes;

public class Review
{
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public string Description { get; set; }
    public int ReviewId { get; set; }
    public int ReviewerId { get; set; }
}