using DashboardApi.Models;

namespace DashboardApi.Repositories.Interfaces;

public interface IUsersRepository
{
    Task AddUser(User user);
    Task DeleteUser(User user);
    Task UpdateUser(ChangeInfoModel model);
    Task<User> GetUser(string username);
    Task<bool> CheckUserAsync(AuthInputModel user);
    Task UploadAvatar();
    Task DownloadAvatar(string username);
    Task ChangePassword(string oldPassword, string newPassword);
    Task AddRevenue(Revenue revenue);
    Task ChangeRevenue(Revenue revenue);
    Task<List<Revenue>> GetRevenues();
}