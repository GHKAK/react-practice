using DashboardApi.Models;
using DashboardApi.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
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

    public async Task<User> GetUserAsync(ObjectId userId)
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

    public async Task<bool> CreateRevenue(ObjectId userId, Revenue revenue)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Id, userId);
        var update = Builders<User>.Update.Push(u => u.Revenues, revenue);
        var result = await _userContext.Users.UpdateOneAsync(filter, update);
        return result.ModifiedCount > 0;
    }

    public async Task<bool> UpdateRevenueAsync(ObjectId userId, Revenue revenue)
    {
        var filter = Builders<User>.Filter.And(
            Builders<User>.Filter.Eq(u => u.Id, userId),
            Builders<User>.Filter.ElemMatch(u => u.Revenues, r => r.Id == revenue.Id));
        var update = Builders<User>.Update
            .Set(u => u.Revenues[0].Amount, revenue.Amount)
            .Set(u => u.Revenues[0].Week, revenue.Week);
        var updateResult = await _userContext.Users.UpdateOneAsync(filter, update);
        return updateResult.MatchedCount > 0;
    }

    public async Task<List<Revenue>> GetRevenuesAsync(ObjectId userId)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Id, userId);
        var projection = Builders<User>.Projection.Expression(u => u.Revenues);
        var result = await _userContext.Users.Find(filter).Project(projection).FirstOrDefaultAsync();
        return result;
    }

    public Task GetRevenueByIdAsync(ObjectId projectId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateTaskAsync(ObjectId userId, TaskModel task)
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

    public async Task<TaskModel> GetTaskByIdAsync(ObjectId userId, ObjectId taskId)
    {
        var filter = Builders<User>.Filter.And(
            Builders<User>.Filter.Eq(u => u.Id, userId),
            Builders<User>.Filter.ElemMatch(u => u.Tasks, t => t.Id == taskId));
        var projection = Builders<User>.Projection.Expression(u => u.Tasks[0]);

        var task = await _userContext.Users.Find(filter).Project(projection).FirstOrDefaultAsync();
        return task;
    }

    public async Task<bool> SetTaskStateAsync(ObjectId userId, ObjectId taskId, bool completed)
    {
        var filter =  Builders<User>.Filter.And(
            Builders<User>.Filter.Eq(u => u.Id, userId),
            Builders<User>.Filter.ElemMatch(u => u.Tasks, r => r.Id == taskId));
        var update = Builders<User>.Update.Set(u => u.Tasks[0].IsCompleted, completed);
        var result = await _userContext.Users.UpdateOneAsync(filter, update);
        return result.ModifiedCount > 0;
    }


    public async Task<bool> CreateProjectAsync(ObjectId userId, Project project)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Id, userId);
        var update = Builders<User>.Update.Push(u => u.Projects, project);
        var result = await _userContext.Users.UpdateOneAsync(filter, update);
        return result.ModifiedCount > 0;
    }

    public async Task<bool> UpdateProjectAsync(ObjectId userId, Project project)
    {
        var filter =  Builders<User>.Filter.And(
            Builders<User>.Filter.Eq(u => u.Id, userId),
            Builders<User>.Filter.ElemMatch(u => u.Projects, r => r.Id == project.Id));
        var update = Builders<User>.Update.Set(u => u.Projects[0], project);
        var result = await _userContext.Users.UpdateOneAsync(filter, update);
        return result.ModifiedCount > 0;    }

    public async Task<bool> DeleteProjectAsync(ObjectId userId, ObjectId projectId)
    {
        var filter =  Builders<User>.Filter.And(
            Builders<User>.Filter.Eq(u => u.Id, userId),
            Builders<User>.Filter.ElemMatch(u => u.Projects, r => r.Id == projectId));
        var update = Builders<User>.Update.PullFilter(u => u.Projects, p=>p.Id==projectId);
        var result = await _userContext.Users.UpdateOneAsync(filter, update);
        return result.ModifiedCount > 0;
    }
    public async Task<Project> GetProjectByIdAsync(ObjectId userId, ObjectId projectId)
    {
        var filter = Builders<User>.Filter.And(
            Builders<User>.Filter.Eq(u => u.Id, userId),
            Builders<User>.Filter.ElemMatch(u => u.Projects, p => p.Id == projectId));
        var projection = Builders<User>.Projection.Expression(u => u.Projects[0]);

        var project = await _userContext.Users.Find(filter).Project(projection).FirstOrDefaultAsync();
        return project;
    }
}