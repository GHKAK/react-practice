using DashboardApi.Models;
using MongoDB.Bson;

namespace DashboardApi.Repositories.Interfaces;

public interface IUsersRepository
{
    Task<bool> CreateUserAsync(User user);
    Task<bool> DeleteUserAsync(ObjectId userId);
    Task<bool> UpdateUserAsync(ObjectId userId, ChangeInfoModel model );
    Task<User> GetUserAsync(ObjectId userId);
    Task<ObjectId> AuthUserAsync(AuthInputModel user);
    Task UploadAvatar(ObjectId userId);
    Task DownloadAvatar(ObjectId userId);
    Task ChangePassword(ObjectId userId, string oldPassword, string newPassword);
    Task<bool> CreateRevenue(ObjectId userId, Revenue revenue);
    Task<bool> UpdateRevenueAsync(ObjectId userId, Revenue revenue);
    Task<List<Revenue>> GetRevenuesAsync(ObjectId userId);
    Task GetRevenueByIdAsync(ObjectId projectId);

    Task<bool> CreateTaskAsync(ObjectId userId, TaskModel task);
    Task<List<TaskModel>> GetTasks();
    Task<TaskModel> GetTaskByIdAsync(ObjectId userId, ObjectId taskId);

    Task<bool> SetTaskStateAsync(ObjectId userId, ObjectId taskId,bool completed);
    Task<bool> CreateProjectAsync(ObjectId userId, Project project);
    Task<bool> UpdateProjectAsync(ObjectId userId, Project project);
    Task<bool> DeleteProjectAsync(ObjectId userId, ObjectId projectId);
    Task<Project> GetProjectByIdAsync(ObjectId userId, ObjectId projectId);


}