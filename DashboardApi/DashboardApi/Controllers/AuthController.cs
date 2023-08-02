using System.IdentityModel.Tokens.Jwt;
using System.Text;
using DashboardApi.Models;
using DashboardApi.Repositories.Interfaces;
using DashboardApi.Services;
using DashboardApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Driver;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsersRepository _usersRepository;
    private readonly IJwtService _jwtService;
    public AuthController(IUsersRepository usersRepository, IJwtService jwtService)
    {
        _usersRepository = usersRepository;
        _jwtService = jwtService;
    }

    [HttpPost("signin")]
    public async Task<IActionResult> SignIn(AuthInputModel user)
    {
        ObjectId userId = await _usersRepository.AuthUserAsync(user);
        if (userId==null)
        {
            return Unauthorized("Invalid credentials");
        }

        var token = _jwtService.GenerateJwtToken(userId);
        return Ok(new { token });
    }

    [HttpPost("validate-token")]
    public IActionResult ValidateToken()
    {
        try
        {
            string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("Token not provided");
            }

            _jwtService.ValidateToken(token);
            return Ok(new { message = "Token is valid" });
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = "Invalid token", error = ex.Message });
        }
    }
}