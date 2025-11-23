using DotnetSecurityIdentiy.Api.Data.Dtos;
using DotnetSecurityIdentiy.Api.Models;
using Microsoft.AspNetCore.Identity;

namespace DotnetSecurityIdentiy.Api.Services;

public class UserServie
{
    private readonly UserManager<User> _userManager;

    public UserServie(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task Register(CreateUserDto createUserDto)
    {
        User user = DotnetSecurityIdentiy.Api.Models.User.ConvertFromDto(createUserDto);

        IdentityResult result = await _userManager.CreateAsync(user, user.PasswordHash);

        if (!result.Succeeded)
        {
            throw new ApplicationException("Failed to create user");
        }
    }
}
