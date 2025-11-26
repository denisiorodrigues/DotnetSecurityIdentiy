using DotnetSecurityIdentiy.Api.Data.Dtos;
using DotnetSecurityIdentiy.Api.Models;
using Microsoft.AspNetCore.Identity;

namespace DotnetSecurityIdentiy.Api.Services;

public class AuthService
{
    private readonly SignInManager<User> _signInManager;
    private TokenService _tokenService;

    public AuthService(SignInManager<User> signInManager, TokenService tokenService)
    {
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<string> Login(LoginUserDto loginUserDto)
    {
        var signInResult = await _signInManager.PasswordSignInAsync(loginUserDto.Username, loginUserDto.Password, false, false);

        if (!signInResult.Succeeded)
        {
            throw new ApplicationException("Invalid username or password");
        }

        var user = await _signInManager.UserManager.FindByNameAsync(loginUserDto.Username);

        var token = _tokenService.GenerateToken(user);

        return token;
    }
}
