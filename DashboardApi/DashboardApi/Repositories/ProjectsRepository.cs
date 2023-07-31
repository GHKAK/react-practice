using DashboardApi.Models;
using DashboardApi.Repositories.Interfaces;
using MongoDB.Bson;

namespace DashboardApi.Repositories;

public class ProjectsRepository : IProjectsRepository
{
    public Task AddProject(Project project)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProject(Project project)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProject(ObjectId projectId)
    {
        throw new NotImplementedException();
    }

    public Task GetProject(ObjectId projectId)
    {
        throw new NotImplementedException();
    }
}