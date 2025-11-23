using DotnetSecurityIdentiy.Api.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DotnetSecurityIdentiy.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    [HttpPost]
    public IActionResult CreateUser(CreateUserDto createUserDto)
    {
        return Ok("User created");
    }
}
