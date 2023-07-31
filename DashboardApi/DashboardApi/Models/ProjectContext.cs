using MongoDB.Driver;

namespace DashboardApi.Models;

public class ProjectContext : MongoContext
{
    public IMongoCollection<Project> Tasks => _database.GetCollection<Project>("projects");

    public ProjectContext(string connectionString, string databaseName) : base(connectionString, databaseName)
    {
    }
}