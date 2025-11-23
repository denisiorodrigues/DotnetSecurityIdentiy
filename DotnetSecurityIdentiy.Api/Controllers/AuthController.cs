using DotnetSecurityIdentiy.Api.Data.Dtos;
using DotnetSecurityIdentiy.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetSecurityIdentiy.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly UserServie userServie;

    public AuthController(UserServie userServie)
    {
        this.userServie = userServie;
    }

    [HttpPost("register")]
    public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
    {
       
        await userServie.Register(createUserDto);

        return Ok("user created successful");
    }
}
