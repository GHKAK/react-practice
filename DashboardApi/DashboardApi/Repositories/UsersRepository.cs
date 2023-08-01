using System.Collections.Immutable;
using DashboardApi.Models;
using DashboardApi.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DashboardApi.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly UserContext _userContext;

    public UsersRepository(UserContext userContext)
    {
        _userContext = userContext;
    }

    public async Task<bool> CreateUserAsync(User user)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Username, user.Username);
        var isNameTaken = await _userContext.Users.Find(filter).AnyAsync();
        if (isNameTaken)
        {
            return false;
        }

        await _userContext.Users.InsertOneAsync(user);
        return true;
    }

    public async Task<bool> DeleteUserAsync(ObjectId userId)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Id, userId);
        var deleteResult = await _userContext.Users.DeleteOneAsync(filter);
        return deleteResult.DeletedCount > 0;
    }

    public async Task<bool> UpdateUserAsync(ObjectId userId, ChangeInfoModel model)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Id, userId);
        var update = Builders<User>.Update
            .Set(u => u.Name, model.Name)
            .Set(u => u.Position, model.Position)
            .Set(u => u.EMail, model.Email)
            .Set(u => u.PhoneNumber, model.PhoneNumber);
        var updateResult = await _userContext.Users.UpdateOneAsync(filter, update);
        return updateResult.MatchedCount > 0;
    }

    public async Task<User> GetUser(ObjectId userId)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Id, userId);
        var user = await _userContext.Users.Find(filter).FirstAsync();
        return user;
    }

    public async Task<ObjectId> AuthUserAsync(AuthInputModel user)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Username, user.Username) &
                     Builders<User>.Filter.Eq(u => u.Password, user.Password);
        var userDocument = await _userContext.Users.Find(filter).FirstOrDefaultAsync();
        return userDocument.Id;
    }

    public Task UploadAvatar(ObjectId userId)
    {
        throw new NotImplementedException();
    }

    public Task DownloadAvatar(ObjectId userId)
    {
        throw new NotImplementedException();
    }

    public Task ChangePassword(ObjectId userId, string oldPassword, string newPassword)
    {
        throw new NotImplementedException();
    }

    public Task CreateRevenue(ObjectId userId, Revenue revenue)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateRevenue(ObjectId userId, RevenueDTO revenue)
    {
        var filter = Builders<User>.Filter.And(
            Builders<User>.Filter.Eq(u => u.Id, userId),
            Builders<User>.Filter.ElemMatch(u => u.Revenues, r => r.Id == ObjectId.Parse(revenue.Id)));
        var update = Builders<User>.Update
            .Set(u => u.Revenues[0].Amount, revenue.Amount)
            .Set(u => u.Revenues[0].Week, revenue.Week);
        var updateResult = await _userContext.Users.UpdateOneAsync(filter, update);
        return updateResult.MatchedCount > 0;
    }

    public Task<List<Revenue>> GetRevenues(ObjectId userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateTask(ObjectId userId, TaskModel task)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Id, userId);
        var update = Builders<User>.Update.Push(u => u.Tasks, task);
        var result = await _userContext.Users.UpdateOneAsync(filter, update);
        return result.ModifiedCount > 0;
    }

    public Task<List<TaskModel>> GetTasks()
    {
        throw new NotImplementedException();
    }

    public Task SetTaskState(ObjectId taskId, bool state)
    {
        throw new NotImplementedException();
    }

    public Task CreateProject(Project project)
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