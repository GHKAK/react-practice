using MongoDB.Bson.Serialization.Attributes;

namespace DashboardApi.Models;

public class TaskStep
{
    [BsonElement("description")] public string Description { get; set; }
    [BsonElement("isCompleted")] public bool IsCompleted { get; set; }
}