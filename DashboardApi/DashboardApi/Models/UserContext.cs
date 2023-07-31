using DashboardApi.Models;
using MongoDB.Driver;

public class UserContext : MongoContext
{
    public IMongoCollection<User> Users => _database.GetCollection<User>("users");

    public UserContext(string connectionString, string databaseName) : base(connectionString, databaseName)
    {
    }
}