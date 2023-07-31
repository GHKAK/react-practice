using DashboardApi.Models;
using DashboardApi.Repositories.Interfaces;
using MongoDB.Driver;

namespace DashboardApi.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly UserContext _userContext;

    public UsersRepository(UserContext userContext)
    {
        _userContext = userContext;
    }

    public Task AddUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUser(ChangeInfoModel model)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUser(string username)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CheckUserAsync(AuthInputModel user)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Username, user.Username) &
                     Builders<User>.Filter.Eq(u => u.Password, user.Password);
        return await _userContext.Users.Find(filter).AnyAsync();
    }

    public Task UploadAvatar()
    {
        throw new NotImplementedException();
    }

    public Task DownloadAvatar(string username)
    {
        throw new NotImplementedException();
    }

    public Task ChangePersonalInfo(ChangeInfoModel model)
    {
        throw new NotImplementedException();
    }

    public Task ChangePassword(string oldPassword, string newPassword)
    {
        throw new NotImplementedException();
    }

    public Task AddRevenue(Revenue revenue)
    {
        throw new NotImplementedException();
    }

    public Task ChangeRevenue(Revenue revenue)
    {
        throw new NotImplementedException();
    }

    public Task<List<Revenue>> GetRevenues()
    {
        throw new NotImplementedException();
    }
}