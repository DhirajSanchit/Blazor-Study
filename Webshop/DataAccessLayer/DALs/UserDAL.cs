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

    public bool CheckForUniqueEmail(string email)
    {
        return CheckForExistingUser(email);
    }


    //Get all users
    private bool CheckForExistingUser(string email)
    {
        try
        {
            //Count the number of users with the same email
            string sql = "SELECT COUNT(*) FROM [User] WHERE EmailAddress = @Email";
            var parameters = new { Email = email };

            var count = _dataAccess.QueryFirstOrDefault<int, dynamic>(sql, parameters);
            if (count > 0)
            {
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public UserDto GetUserByLogin(string email, string password)
    {
        try
        {
            var sql = @"SElECT UserId, FirstName, LastName, EmailAddress, R2.Description AS Role, Password
                    FROM [User]
                    LEFT JOIN Role R2 
                    on R2.RoleId = [User].RoleId
                    WHERE [User].EmailAddress = @EmailAddress AND [User].Password = @Password";

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

    public bool RegisterCustomer(UserDto user)
    {
        //check if user already exists
        if (!CheckForExistingUser(user.EmailAdress))
        {
            try
            {
                var sql = @"INSERT INTO [User] (FirstName, LastName, EmailAddress, RoleId, Password)
                        VALUES (@FirstName, @LastName, @EmailAddress, @RoleId, @Password)";
                
                var role = _dataAccess.QueryFirstOrDefault<int, dynamic>("SELECT RoleId FROM Role WHERE Description = 'Customer'", new{});

                var parameters = new
                {
                    @FirstName = user.FirstName, @LastName = user.LastName, @EmailAddress = user.EmailAdress,
                    @RoleId = role, @Password = user.Password
                };
                var rowsAffected = _dataAccess.ExecuteCommand(sql, parameters);
                if (rowsAffected > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        return false;
    }
}