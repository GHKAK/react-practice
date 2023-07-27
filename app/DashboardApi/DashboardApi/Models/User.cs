using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DashboardApi.Models;

public class User {
    public ObjectId _id;
    [BsonElement("username")]
    public string Username { get; set; }
    [BsonElement("password")]
    public string Password { get; set; }
}