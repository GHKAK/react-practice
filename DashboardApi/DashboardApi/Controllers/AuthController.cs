using DashboardApi.Models;
using DashboardApi.Repositories.Interfaces;
using DashboardApi.Services;
using DashboardApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        bool isUserExists = await _usersRepository.CheckUserAsync(user);
        if (!isUserExists)
        {
            return Unauthorized("Invalid credentials");
        }

        var token = _jwtService.GenerateJwtToken(user.Username);
        return Ok(new { token });
    }
}