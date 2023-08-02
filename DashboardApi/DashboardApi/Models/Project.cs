using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DashboardApi.Models;

public class Project
{
    public Project()
    {
        Id = ObjectId.GenerateNewId();        
    }
    [BsonId] public ObjectId Id;
    [BsonElement("startDate")] public DateTime StartDate { get; set; }
    [BsonElement("title")] public string Title { get; set; }
    [BsonElement("stage")] public string Stage { get; set; }
    [BsonElement("description")] public string Description { get; set; }
    [BsonElement("progress")] public byte Progress { get; set; }
    [BsonElement("projectMembers")] public List<ProjectMember> ProjectMembers { get; set; }
}