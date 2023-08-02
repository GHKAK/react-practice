using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DashboardApi.Models;

public class Revenue
{
    public Revenue()
    {
        Id = ObjectId.GenerateNewId();        
    }

    /// <summary>
    /// The unique identifier for the revenue entry.
    /// </summary>
    [BsonId] public ObjectId Id;

    /// <summary>
    /// The amount of revenue.
    /// </summary>
    [BsonElement("amount")] public int Amount { get; set; }
    /// <summary>
    /// The week of the revenue.
    /// </summary>
    [BsonElement("week")] public DateTime Week { get; set; }
}