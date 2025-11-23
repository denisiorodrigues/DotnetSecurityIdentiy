using DotnetSecurityIdentiy.Api.Data.Dtos;
using DotnetSecurityIdentiy.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotnetSecurityIdentiy.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    public AuthController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
    {
        User user = DotnetSecurityIdentiy.Api.Models.User.ConvertFromDto(createUserDto);

        IdentityResult result = await _userManager.CreateAsync(user, user.PasswordHash);

       if(!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Ok("user created successful");
    }
}
