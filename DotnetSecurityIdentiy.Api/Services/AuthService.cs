using DotnetSecurityIdentiy.Api.Data.Dtos;
using DotnetSecurityIdentiy.Api.Models;
using Microsoft.AspNetCore.Identity;

namespace DotnetSecurityIdentiy.Api.Services;

public class AuthService
{
    private readonly SignInManager<User> _signInManager;
    public AuthService(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task Login(LoginUserDto loginUserDto)
    {
        var signInResult = await _signInManager.PasswordSignInAsync(loginUserDto.Username, loginUserDto.Password, false, false);

        if (!signInResult.Succeeded)
        {
            throw new ApplicationException("Invalid username or password");
        }
    }
}
