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
    private readonly IConfiguration _configuration;

    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
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

    public void ValidateToken(string token)
    {
        string secretKey = _configuration["Jwt:PrivateKey"];
        string issuer = _configuration["Jwt:Issuer"];
        string audience = _configuration["Jwt:Audience"];

        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(secretKey)),
            ValidateIssuer = true,
            ValidIssuer = issuer,
            ValidateAudience = true,
            ValidAudience = audience,
        };
        SecurityToken validatedToken;
        var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
    }
}