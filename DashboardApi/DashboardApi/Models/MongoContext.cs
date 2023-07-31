using MongoDB.Driver;

namespace DashboardApi.Models;

public class MongoContext
{    
    private protected readonly IMongoDatabase _database;

    public MongoContext(string connectionString, string databaseName) {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }
}