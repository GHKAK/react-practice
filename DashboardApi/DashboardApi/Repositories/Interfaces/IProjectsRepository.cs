using DashboardApi.Models;
using MongoDB.Bson;

namespace DashboardApi.Repositories.Interfaces;

public interface IProjectsRepository
{
    Task AddProject(Project project);
    Task UpdateProject(Project project);
    Task DeleteProject(ObjectId projectId);
    Task GetProject(ObjectId projectId);
}