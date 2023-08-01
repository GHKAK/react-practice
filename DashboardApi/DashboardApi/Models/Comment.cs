using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DashboardApi.Models;

public class Comment
{
    [BsonId] public ObjectId Id;
    [BsonElement("text")] public string Text;
}