using System.Security.Claims;
using DashboardApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DashboardApi.Models;
using Microsoft.AspNetCore.Authorization;
using MongoDB.Bson;

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
        var isNameFree = await _usersRepository.CreateUserAsync(user);
        if (!isNameFree)
        {
            return BadRequest("username is already taken");
        }

        return Ok();
    }

    [HttpDelete("user")]
    [Authorize]
    public async Task<IActionResult> DeleteUser()
    {
        ObjectId userId = GetUserId(User);
        var isDeleted = await _usersRepository.DeleteUserAsync(userId);
        if (!isDeleted)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPatch("edit")]
    [Authorize]
    public async Task<IActionResult> UpdateUserInfo(ChangeInfoModel userInfo)
    {
        ObjectId userId = GetUserId(User);
        var isUpdated = await _usersRepository.UpdateUserAsync(userId, userInfo);
        if (!isUpdated)
        {
            return NotFound();
        }
        return Ok("Updated successfully");
    }

    [HttpPut("revenue")]
    [Authorize]
    public async Task<IActionResult> UpdateRevenue([FromBody]RevenueDTO revenue)
    {
        ObjectId userId = GetUserId(User); 
        var isUpdated = await _usersRepository.UpdateRevenue(userId, revenue);
        if (!isUpdated)
        {
            return NotFound();
        }
        return Ok("Updated successfully");
    }

    [HttpGet("user")]
    [Authorize]
    public async Task<IActionResult> GetUser()
    {
        ObjectId userId = GetUserId(User);
        try
        {
            var foundUser = await _usersRepository.GetUser(userId);
            return Ok(foundUser);
        }
        catch
        {
            return NotFound();
        }
    }

    public static ObjectId GetUserId(ClaimsPrincipal user)
    {
        return ObjectId.Parse(user.Claims.First()?.Value);
    }
}