using System.Security.Cryptography;

namespace DashboardApi.Services.Interfaces; 

public interface IJwtService {
    RSAParameters GetPublicKey();
    RSAParameters GetPrivateKey();
    string GenerateJwtToken(string username);
}