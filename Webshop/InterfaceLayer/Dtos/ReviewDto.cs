namespace InterfaceLayer.Dtos;

public record ReviewDto
{
    public DateTime Date { get; init; }
    public int Score { get; init; }
    public string Description { get; init; }
    public int ReviewId { get; init; }
    public int ReviewerId { get; init; }   
}