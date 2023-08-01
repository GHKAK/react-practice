using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DashboardApi.Models;

public class Project
{
    [BsonId] public ObjectId Id;
    [BsonElement("startDate")] public DateTime StartDate { get; set; }
    [BsonElement("title")] public string Title { get; set; }
    [BsonElement("stage")] public string Stage { get; set; }
    [BsonElement("description")] public string Description { get; set; }
    [BsonElement("progress")] public byte Progress { get; set; }
    [BsonElement("workers")] public List<ObjectId> Workers { get; set; }
}