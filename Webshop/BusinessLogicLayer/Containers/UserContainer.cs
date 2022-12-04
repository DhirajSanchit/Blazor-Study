using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Helpers;
using BusinessLogicLayer.Interfaces;
using InterfaceLayer.DALs;

namespace BusinessLogicLayer.Containers;

public class UserContainer : IUserContainer
{
    private readonly IUserDAL _userDAL;

    public UserContainer(IUserDAL userDAL)
    {
        _userDAL = userDAL;
    }
    

    public User GetByUsernameAndPassword(string username, string password)
    {
        try
        {
            return new User(_userDAL.GetUserByLogin(username, password.Sha256()));
        }
        catch
        {
            return null;
        }
    }

    public User GetByGoogleId(string googleId)
    {
        //var user = LocalUsers.SingleOrDefault(u => u.GoogleId == googleId);
        //return user;
        return null;
    }
}