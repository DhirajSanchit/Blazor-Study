namespace InterfaceLayer.Dtos;

public record  UserDto
{
    public int UserId { get; init; }
    public string Name { get; init; }
    public string FirstName { get; init; }
    
    public string LastName { get; init; }
    public string EmailAdress { get; init; }
    public string Password { get; init; }
    public string Role { get; init; }
}