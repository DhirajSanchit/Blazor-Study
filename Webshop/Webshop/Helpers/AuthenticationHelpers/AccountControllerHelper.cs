using BusinessLogicLayer.Classes;
using Webshop.Models;

namespace Webshop.Helpers.AuthenticationHelpers;

public class AccountControllerHelper
{
    public static User ToUser(RegistrationModel model)
    {
        return new User()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            EmailAddress = model.EmailAddress,
            Password = model.Password,
        };
    }
}