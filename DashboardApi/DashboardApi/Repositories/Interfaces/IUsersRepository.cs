using DashboardApi.Models;
using MongoDB.Bson;

namespace DashboardApi.Repositories.Interfaces;

public interface IUsersRepository
{
    Task<bool> CreateUserAsync(User user);
    Task<bool> DeleteUserAsync(ObjectId userId);
    Task<bool> UpdateUserAsync(ObjectId userId, ChangeInfoModel model );
    Task<User> GetUser(ObjectId userId);
    Task<ObjectId> AuthUserAsync(AuthInputModel user);
    Task UploadAvatar(ObjectId userId);
    Task DownloadAvatar(ObjectId userId);
    Task ChangePassword(ObjectId userId, string oldPassword, string newPassword);
    Task CreateRevenue(ObjectId userId, Revenue revenue);
    Task<bool> UpdateRevenue(ObjectId userId, RevenueDTO revenue);
    Task<List<Revenue>> GetRevenues(ObjectId userId);
    Task<bool> CreateTask(ObjectId userId, TaskModel task);
    Task<List<TaskModel>> GetTasks();
    Task SetTaskState(ObjectId taskId,bool state);
    Task CreateProject(Project project);
    Task UpdateProject(Project project);
    Task DeleteProject(ObjectId projectId);
    Task GetProject(ObjectId projectId);
}