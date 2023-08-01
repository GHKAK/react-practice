using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DashboardApi.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;

namespace DashboardApi.Services;

public class JwtService : IJwtService
{
    private readonly JwtHeader _jwtHeader;

    public JwtService(IConfiguration configuration)
    {
        var credentials = new SigningCredentials(
            key: new SymmetricSecurityKey(Encoding.UTF32.GetBytes(configuration["Jwt:PrivateKey"])),
            algorithm: SecurityAlgorithms.HmacSha256);
        _jwtHeader = new JwtHeader(credentials);
    }

    public string GenerateJwtToken(ObjectId userId)
    {
        var jwtClaims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            _jwtHeader,
            new JwtPayload(
                audience: "identity",
                issuer: "identity",
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(1),
                claims: jwtClaims
            )
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}