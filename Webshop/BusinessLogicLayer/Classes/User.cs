using InterfaceLayer.Dtos;

namespace BusinessLogicLayer.Classes;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string email { get; set; }
    public string Role { get; set; }
    public string GoogleId { get; set; }
    
    
    public User()
    {
    }
    
    //constructor for user with dto
    public User(UserDto dto)
    {
        Id = dto.UserId;
        Name = dto.FirstName;
        Password = dto.Password;
        email = dto.EmailAdress;
        Role = dto.Role;
        GoogleId = dto.GoogleId;
    }
    
    //Method to convert user to userDTO
    public UserDto ToDTO()
    {
        return new UserDto()
        {
            UserId = Id,
            Name = Name,
            Password = Password,
            Role = Role,
            GoogleId = GoogleId
        };
    }
}