using DashboardApi.Models;
using DashboardApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace DashboardApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly ITasksRepository _tasksRepository;

    public TasksController(ITasksRepository tasksRepository)
    {
        _tasksRepository = tasksRepository;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateTask(TaskModel task)
    {
        throw new NotImplementedException();
    }

    [HttpPatch("{task_id}/state")]
    public async Task<IActionResult> UpdateState(ObjectId task_id)
    {
        throw new NotImplementedException();
    }
}