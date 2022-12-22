using System.ComponentModel.DataAnnotations;
using InterfaceLayer.Dtos;

namespace BusinessLogicLayer.Classes;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Password { get; set; }
    public string EmailAddress { get; set; }
    public string Role { get; set; }
    
    
    public User()
    {
    }
    
    //constructor for user with dto
    public User(UserDto dto)
    {
        Id = dto.UserId;
        Name = dto.FirstName + " " + dto.LastName;
        FirstName = dto.FirstName;
        LastName = dto.LastName;
        Password = dto.Password;
        EmailAddress = dto.EmailAdress;
        Role = dto.Role;
    }
    
    //Method to convert user to userDTO
    public UserDto ToDTO()
    {
        return new UserDto()
        {
            UserId = Id,
            Name = Name,
            FirstName = FirstName,
            LastName = LastName,
            Password = Password,
            EmailAdress = EmailAddress,
            Role = Role,
        };
    }
}