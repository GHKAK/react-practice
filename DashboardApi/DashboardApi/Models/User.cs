using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DashboardApi.Models;

public class User
{
    public ObjectId _id;
    [BsonElement("username")] public string Username { get; set; }

    [BsonElement("password")] public string Password { get; set; }

    [BsonElement("name")] public string Name { get; set; }
    [BsonElement("position")] public string Position { get; set; }
    [BsonElement("accessType")] public string AccessType { get; set; }
    [BsonElement("eMail")] public string EMail { get; set; }
    [BsonElement("phoneNumber")] public string PhoneNumber { get; set; }
    [BsonElement("overallRating")] public float OverallRating { get; set; }
    [BsonElement("avatarFileName")] public string avatarFileName { get; set; }
    [BsonElement("projectsIds")] public List<ObjectId> ProjectsIds { get; set; }
    [BsonElement("tasksIds")] public List<ObjectId> TasksIds { get; set; }
    [BsonElement("revenueIds")] public List<ObjectId> RevenueIds { get; set; }
}