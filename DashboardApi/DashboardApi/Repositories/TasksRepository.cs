using DashboardApi.Models;
using DashboardApi.Repositories.Interfaces;
using MongoDB.Bson;

namespace DashboardApi.Repositories;

public class TasksRepository :ITasksRepository
{
    public Task CreateTaks(TaskModel task)
    {
        throw new NotImplementedException();
    }

    public Task<List<TaskModel>> GetTasks()
    {
        throw new NotImplementedException();
    }

    public Task SetTaskState(ObjectId taskId, bool state)
    {
        throw new NotImplementedException();
    }
}