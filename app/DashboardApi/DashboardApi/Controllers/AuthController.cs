using DashboardApi.Models;
using DashboardApi.Services;
using DashboardApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase {
    private readonly UserContext _userContext;
    private readonly IJwtService _jwtService;
    public AuthController(UserContext userContext,IJwtService jwtService) {
        _userContext = userContext;
        _jwtService = jwtService;
    }

    [HttpPost("signin")]
    public IActionResult SignIn([FromBody] User user) {
        var filter = Builders<User>.Filter.Eq(u => u.Username, user.Username) &
                     Builders<User>.Filter.Eq(u => u.Password, user.Password);
        var existingUser = _userContext.Users.Find(filter).FirstOrDefault();
        if (existingUser == null) {
            return Unauthorized("Invalid credentials");
        }

        var token = _jwtService.GenerateJwtToken(user.Username);
        return Ok(new {token});
    }
}