using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DashboardApi.Models;

public class ProjectMember
{
    public ProjectMember()
    {
        Id = ObjectId.GenerateNewId();        
    }

    [BsonId] public ObjectId Id;
    [BsonElement("username")] public string Username { get; set; }
}