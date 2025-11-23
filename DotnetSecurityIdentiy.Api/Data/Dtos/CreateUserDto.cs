using System.ComponentModel.DataAnnotations;

namespace DotnetSecurityIdentiy.Api.Data.Dtos;

public class CreateUserDto
{
    [Required]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }
}
