using AutoMapper;
using DashboardApi.Models;
using DashboardApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace DashboardApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;
    public ProjectsController(IUsersRepository usersRepository,IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }
    [HttpPost("create")]
    [Authorize]
    public async Task<IActionResult> CreateProject(Project project)
    {
        ObjectId userId = UsersController.GetUserId(User);
        var isCreated = await _usersRepository.CreateProjectAsync(userId, project);
        if (!isCreated)
        {
            return BadRequest();
        }

        return Ok("Created successfully!");
    }
    [HttpGet("{projectId}")]
    [Authorize]
    public async Task<IActionResult> GetTaskById(string projectId)
    {
        ObjectId userId = UsersController.GetUserId(User);
        ObjectId parsedProjectId = ObjectId.Parse(projectId);
        var foundedProject = await _usersRepository.GetProjectByIdAsync(userId, parsedProjectId);
        if (foundedProject == null)
        {
            return NotFound();
        }
        var projectDto = _mapper.Map<ProjectDTO>(foundedProject);
        return Ok(projectDto);
    }

    [HttpPut("edit")]
    [Authorize]
    public async Task<IActionResult> UpdateProject(ProjectDTO projectDto)
    {
        ObjectId userId = UsersController.GetUserId(User);
        var project = _mapper.Map<Project>(projectDto);
        var isUpdated = await _usersRepository.UpdateProjectAsync(userId, project);
        if (!isUpdated)
        {
            return NotFound();
        }
        return Ok("Updated Successfully");
    }

    [HttpDelete("{projectId}")]
    [Authorize]
    public async Task<IActionResult> DeleteProject(string projectId)
    {
        ObjectId userId = UsersController.GetUserId(User);
        ObjectId parsedProjectId = ObjectId.Parse(projectId);
        var isDeleted = await _usersRepository.DeleteProjectAsync(userId, parsedProjectId);
        if (!isDeleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}