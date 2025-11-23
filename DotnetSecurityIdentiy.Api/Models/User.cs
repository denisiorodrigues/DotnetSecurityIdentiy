using DotnetSecurityIdentiy.Api.Data.Dtos;
using Microsoft.AspNetCore.Identity;

namespace DotnetSecurityIdentiy.Api.Models;

public class User : IdentityUser
{
    public DateTime DateOfBirth { get; private set; }

    public static User ConvertFromDto(CreateUserDto createUserDto) => new User
    {
       UserName = createUserDto.Username,
       PasswordHash = createUserDto.Password,
        //PasswordHash = BCrypt.Net.BCrypt.HashPassword(createUserDto.Password),
        DateOfBirth = createUserDto.DateOfBirth
    };
}
