using System.ComponentModel.DataAnnotations;

namespace DashboardApi.Models;

public class AuthInputModel
{
    /// <summary>
    /// Default example username.
    /// </summary>
    /// <example>admin</example>
    [Required]
    public string Username { get; set; }

    /// <summary>
    /// Default example password.
    /// </summary>
    /// <example>123</example>
    [Required]
    public string Password { get; set; }
}