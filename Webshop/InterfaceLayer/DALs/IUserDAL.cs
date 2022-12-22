using InterfaceLayer.Dtos;

namespace InterfaceLayer.DALs;

public interface IUserDAL
{
    UserDto GetUserByLogin(string email, string password);
    bool RegisterCustomer(UserDto user);
    bool CheckForUniqueEmail(string email);
}