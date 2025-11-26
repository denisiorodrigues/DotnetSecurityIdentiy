using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DotnetSecurityIdentiy.Api.Models;
using Microsoft.IdentityModel.Tokens;

namespace DotnetSecurityIdentiy.Api.Services;

public class TokenService
{
    public string GenerateToken(User user)
    {
        Claim[] claims = new[]
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth.ToString("yyyy-MM-dd"))
        };
        
        var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("ThisIsAVerySecureAndLongSecretKeyForHS256Algorithm")!);
        var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddMinutes(10),
            claims: claims,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}