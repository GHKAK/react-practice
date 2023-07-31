using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DashboardApi.Models;

public class TaskModel
{
    public ObjectId _id { get; set; }
    [BsonElement("isCompleted")] public bool IsCompleted { get; set; }
    [BsonElement("title")] public string Title { get; set; }
    [BsonElement("deadline")] public DateTime Deadline { get; set; }
    [BsonElement("steps")] public List<TaskStep> Steps { get; set; }
    [BsonElement("comments")] public List<Comment> Comments { get; set; }
    [BsonElement("priority")] public string Priority { get; set; }
}