using BusinessLogicLayer.Classes;

namespace BusinessLogicLayer.Interfaces;

public interface IUserContainer
{
    User GetByUsernameAndPassword(string username, string password);
    User GetByGoogleId(string googleId);
}