using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DashboardApi.Models;

public class Revenue
{
    public ObjectId _id;
    [BsonElement("amount")] public int Amount { get; set; }
    [BsonElement("week")] public DateTime Week { get; set; }
}