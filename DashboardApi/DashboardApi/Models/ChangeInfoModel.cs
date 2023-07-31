using System.ComponentModel.DataAnnotations;

namespace DashboardApi.Models;

public class ChangeInfoModel
{
    /// <example>Elizabeth Foster</example>
    [Required]
    public string Name { get; set; }

    /// <example>Web & Graphic Designer</example>
    [Required]
    public string Position { get; set; }

    /// <example>xyz@mail.com</example>
    [Required]
    public string Email { get; set; }

    /// <example>+00 123-456-789</example>
    [Required]
    public string PhoneNumber { get; set; }
}