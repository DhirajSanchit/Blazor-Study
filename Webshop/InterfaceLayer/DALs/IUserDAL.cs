using InterfaceLayer.Dtos;

namespace InterfaceLayer.DALs;

public interface IUserDAL
{
    bool CheckForExistingUser(string email, string password);
    UserDto GetUserByLogin(string email, string password);
}