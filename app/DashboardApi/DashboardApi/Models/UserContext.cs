using DashboardApi.Models;
using MongoDB.Driver;

public class UserContext {
    private readonly IMongoDatabase _database;
    public IMongoCollection<User> Users => _database.GetCollection<User>("users");

    public UserContext(string connectionString, string databaseName) {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }
}