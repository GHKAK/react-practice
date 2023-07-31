using DashboardApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DashboardApi.Models;
namespace DashboardApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUsersRepository _usersRepository;

    public UsersController(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    
    [HttpPost("signup")]
    public async Task<IActionResult> CreateUser(User user)
    {
        try
        {
            _usersRepository.AddUser(user);
        }
        catch
        {
            return BadRequest(); //UnprocessableEntity()
        }

        return Ok();
    }

    [HttpDelete("{username}")]
    public async Task<IActionResult> DeleteUser(string username)
    {
        throw new NotImplementedException();
    }

    [HttpPatch("edit")]
    public async Task<IActionResult> UpdateUserInfo(ChangeInfoModel userInfo)
    {
        throw new NotImplementedException();
    }

    [HttpPut("revenue")]
    public async Task<IActionResult> UpdateRevenue(Revenue revenue)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{username}")]
    public async Task<IActionResult> GetUser(string username)
    {
        throw new NotImplementedException();
    }
}