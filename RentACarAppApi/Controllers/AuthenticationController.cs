using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RentACarAppApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _config;

    public AuthenticationController(IConfiguration config)
    {
        _config = config;
    }
    public record AuthenticationData(string? Email, string? Password);
    public record UserData(int Id, string FirstName, string LastName, string Email);

    [HttpPost("token")]
    [AllowAnonymous]
    public ActionResult<string> AuthenticateUser([FromBody] AuthenticationData data)
    {
        UserData? validUser = ValidateUser(data);

        if (validUser == null)
        {
            return Unauthorized();
        }

        string token = GenerateToken(validUser);

        return Ok(token);
    }

    private string GenerateToken(UserData validUser)
    {
        // Secret Key for Signing Credentials
        var key = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(_config.GetValue<string>("Authentication:SecretKey")));

        // Signing Credentials
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Claims
        List<Claim> claims = new List<Claim>();
        claims.Add(new(JwtRegisteredClaimNames.Sub, validUser.Id.ToString()));
        claims.Add(new(JwtRegisteredClaimNames.UniqueName, validUser.Email));
        claims.Add(new(JwtRegisteredClaimNames.GivenName, validUser.FirstName));
        claims.Add(new(JwtRegisteredClaimNames.FamilyName, validUser.LastName));

        // Creating Token
        var token = new JwtSecurityToken(
            _config.GetValue<string>("Authentication:Issuer"),
            _config.GetValue<string>("Authentication:Audience"),
            claims,
            DateTime.Now,
            DateTime.Now.AddMinutes(2),
            signingCredentials);

        // Writing and Returning Token
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private UserData? ValidateUser(AuthenticationData data)
    {
        // THIS SHOULD NOT BE USED IN DEPLOYMENT
        if(CompareValues(data.Email, "tcorey@timcorey.com") &&
            CompareValues(data.Password, "Test123"))
        {
            return new UserData(1, "Tim", "Corey", data.Email!);
        }
        if (CompareValues(data.Email, "sstorm@timcorey.com") &&
            CompareValues(data.Password, "Test123"))
        {
            return new UserData(1, "Tim", "Corey", data.Email!);
        }

        return null;
    }

    private bool CompareValues(string? actual, string expected)
    {
        if (actual != null)
        {
            if (actual.Equals(expected)) 
            { 
                return true;
            }
        }

        return false;
    }
}
