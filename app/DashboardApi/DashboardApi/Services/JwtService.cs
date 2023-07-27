using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DashboardApi.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace DashboardApi.Services;

public class JwtService : IJwtService {
    private readonly RSAParameters publicKeyParameters;
    private readonly RSAParameters privateKeyParameters;

    public JwtService() {
        using (var rsa = new RSACryptoServiceProvider(2048)) {
            publicKeyParameters = rsa.ExportParameters(false);
            privateKeyParameters = rsa.ExportParameters(true);
        }
    }

    public RSAParameters GetPublicKey() {
        return publicKeyParameters;
    }

    public RSAParameters GetPrivateKey() {
        return privateKeyParameters;
    }
    public string GenerateJwtToken(string username) {
        var securityKey = new RsaSecurityKey(privateKeyParameters);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.RsaSha256);

        var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: "https://localhost:7178",
            audience: "https://localhost:7178/resources",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}