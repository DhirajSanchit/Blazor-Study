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
    

    public User GetByEmailAndPassword(string username, string password)
    {
        try
        {
            return new User(_userDAL.GetUserByLogin(username, password.Sha256()));
        }
        catch
        {
            return null!;
        }
    }

    public bool RegisterCustomer(User user)
    {
        //prep the user
        var registrant = PrepRegistration(user);
        
        try
        {
            return _userDAL.RegisterCustomer(registrant.ToDTO());
        }
        catch
        {
            return false;
        }
    }

    public User GetByGoogleId(string googleId)
    {
        //var user = LocalUsers.SingleOrDefault(u => u.GoogleId == googleId);
        //return user;
        return null!;
    }

    public bool CheckForUniqueEmail(string email)
    {
        return _userDAL.CheckForUniqueEmail(email);
    }

    private User PrepRegistration(User registrant)
    { 
        var processed = registrant;
        processed.EmailAddress = registrant.EmailAddress.ToLower();
        processed.Password = registrant.Password.Sha256();
        return processed;
    }
}