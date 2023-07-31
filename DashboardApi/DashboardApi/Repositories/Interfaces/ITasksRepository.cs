using DashboardApi.Models;
using MongoDB.Bson;

namespace DashboardApi.Repositories.Interfaces;

public interface ITasksRepository
{
    Task CreateTaks(TaskModel task);
    Task<List<TaskModel>> GetTasks();
    Task SetTaskState(ObjectId taskId,bool state);
}