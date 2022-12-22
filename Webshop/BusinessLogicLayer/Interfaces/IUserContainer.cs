using BusinessLogicLayer.Classes;

namespace BusinessLogicLayer.Interfaces;

public interface IUserContainer
{
    User GetByEmailAndPassword(string username, string password);
    bool RegisterCustomer(User user);
    User GetByGoogleId(string googleId);
    bool CheckForUniqueEmail(string email);
}