using DotnetSecurityIdentiy.Api.Data.Dtos;
using DotnetSecurityIdentiy.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetSecurityIdentiy.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly UserServie userServie;
    private readonly AuthService authService;

    public AuthController(UserServie userServie, AuthService authService)
    {
        this.userServie = userServie;
        this.authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
    {
       
        await userServie.Register(createUserDto);

        return Ok("user created successful");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDto loginUserDto)
    {
        var token = await authService.Login(loginUserDto);
        return Ok(token);
    }
}
        