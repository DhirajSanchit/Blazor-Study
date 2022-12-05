using InterfaceLayer.DALs;
using InterfaceLayer.Dtos;

namespace DataAccessLayer.DALs;

public class UserDAL : IUserDAL
{
    private readonly IDataAccess _dataAccess;

    public UserDAL(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }


    //Get all users
    public bool CheckForExistingUser(string email, string password)
    {
        //var sql = "SELECT * FROM [User] WHERE email = @Email AND [User].Password = @Password";
        throw new NotImplementedException();
    }

    public UserDto GetUserByLogin(string email, string password)
    {
        try
        {
            var sql = @"SElECT UserId, FirstName, LastName, EmailAddress, R2.Description AS Role, Password
                    FROM [User]
                    LEFT JOIN Role R2 
                    on R2.RoleId = [User].RoleId
                    WHERE EmailAddress = @EmailAddress AND Password = @Password";

            var parameters = new { @EmailAddress = email, @Password = password };
            var user = _dataAccess.QueryFirstOrDefault<UserDto, dynamic>(sql, parameters);
            return user;
        }
        catch (NullReferenceException nre)
        {
            Console.WriteLine("Error, no user found");
            throw nre;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}