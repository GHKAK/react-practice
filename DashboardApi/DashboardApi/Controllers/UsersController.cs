using System.Security.Claims;
using AutoMapper;
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
    private readonly IMapper _mapper;

    public UsersController(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
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

    [HttpGet("revenues")]
    [Authorize]
    public async Task<IActionResult> GetRevenues()
    {
        ObjectId userId = GetUserId(User);
        var revenuesList = await _usersRepository.GetRevenuesAsync(userId);
        if (revenuesList == null)
        {
            return NotFound();
        }

        var revenuesDtoList = _mapper.Map<List<RevenueDTO>>(revenuesList);
        return Ok(revenuesDtoList);
    }

    [HttpPost("revenue")]
    [Authorize]
    public async Task<IActionResult> CreateRevenue(Revenue revenue)
    {
        ObjectId userId = UsersController.GetUserId(User);
        var isCreated = await _usersRepository.CreateRevenue(userId, revenue);
        if (!isCreated)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpPut("revenue")]
    [Authorize]
    public async Task<IActionResult> UpdateRevenue([FromBody] RevenueDTO revenueDto)
    {
        ObjectId userId = GetUserId(User);
        var revenue = _mapper.Map<Revenue>(revenueDto);
        var isUpdated = await _usersRepository.UpdateRevenueAsync(userId, revenue);
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

        var foundUser = await _usersRepository.GetUserAsync(userId);
        if (foundUser == null)
        {
            return NotFound();
        }

        var userDto = _mapper.Map<UserDTO>(foundUser);
        return Ok(userDto);
    }

    public static ObjectId GetUserId(ClaimsPrincipal user)
    {
        return ObjectId.Parse(user.Claims.First()?.Value);
    }
}
