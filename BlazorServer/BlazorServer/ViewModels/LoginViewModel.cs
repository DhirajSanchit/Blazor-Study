using System.ComponentModel.DataAnnotations;

namespace BlazorServer.ViewModels;

public class LoginViewModel
{
    [Required]
    [StringLength(100)]
    public string UserName { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 8)]
    public string Password { get; set; }
}