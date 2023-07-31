using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DashboardApi.Models;

public class Comment
{
    public ObjectId _id;
    [BsonElement("text")]public string Text;
}