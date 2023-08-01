using DashboardApi.Models;
using DashboardApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace DashboardApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly IUsersRepository _usersRepository;

    public TasksController(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    [HttpPost("create")]
    [Authorize]
    public async Task<IActionResult> CreateTask(TaskModel task)
    {
        ObjectId userId = UsersController.GetUserId(User);
        var isCreated = await _usersRepository.CreateTask(userId, task);
        if (!isCreated)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpPatch("{task_id}/state")]
    public async Task<IActionResult> UpdateState(string task_id)
    {
        throw new NotImplementedException();
    }
}