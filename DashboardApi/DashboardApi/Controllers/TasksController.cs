using AutoMapper;
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
    private readonly IMapper _mapper;
    public TasksController(IUsersRepository usersRepository,IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    [HttpPost("create")]
    [Authorize]
    public async Task<IActionResult> CreateTask(TaskModel task)
    {
        ObjectId userId = UsersController.GetUserId(User);
        var isCreated = await _usersRepository.CreateTaskAsync(userId, task);
        if (!isCreated)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpPatch("{taskId}/state")]
    [Authorize]
    public async Task<IActionResult> UpdateState(string taskId, [FromBody] bool state)
    {
        ObjectId userId = UsersController.GetUserId(User);
        ObjectId parsedTaskId = ObjectId.Parse(taskId);
        var isUpdated = await _usersRepository.SetTaskStateAsync(userId, parsedTaskId, state);
        if (!isUpdated)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpGet("{taskId}")]
    [Authorize]
    public async Task<IActionResult> GetTaskById(string taskId)
    {
        ObjectId userId = UsersController.GetUserId(User);
        ObjectId parsedTaskId = ObjectId.Parse(taskId);
        var foundedTask = await _usersRepository.GetTaskByIdAsync(userId, parsedTaskId);
        if (foundedTask == null)
        {
            return NotFound();
        }

        var foundedTaskDto = _mapper.Map<TaskDTO>(foundedTask);
        return Ok(foundedTaskDto);
    }
}