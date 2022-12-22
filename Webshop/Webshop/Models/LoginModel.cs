using System.ComponentModel.DataAnnotations;

namespace Webshop.Models;

public class LoginModel
{
    
    
    [Required (ErrorMessage = "Please enter your username")]
    public string Username { get; set; }
    
    [Required (ErrorMessage = "Please enter your password")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public bool RememberMe { get; set; }
    public string ReturnUrl { get; set; }
}