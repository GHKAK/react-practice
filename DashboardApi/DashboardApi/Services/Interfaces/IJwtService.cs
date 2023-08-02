using System.Security.Cryptography;
using MongoDB.Bson;

namespace DashboardApi.Services.Interfaces; 

public interface IJwtService {
    string GenerateJwtToken(ObjectId userId);
    void ValidateToken(string token);
}