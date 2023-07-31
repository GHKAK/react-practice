using MongoDB.Driver;

namespace DashboardApi.Models;

public class TaskContext : MongoContext
{
    public IMongoCollection<TaskModel> Tasks => _database.GetCollection<TaskModel>("tasks");

    public TaskContext(string connectionString, string databaseName) : base(connectionString, databaseName)
    {
    }
}