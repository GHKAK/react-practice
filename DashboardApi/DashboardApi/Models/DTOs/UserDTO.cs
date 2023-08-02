namespace DashboardApi.Models;

public class UserDTO
{
    public string Id { get; set; }
    public string Username { get; set; }

    public string Password { get; set; }

    public string Name { get; set; }
    public string Position { get; set; }
    public string AccessType { get; set; }
    public string EMail { get; set; }
    public string PhoneNumber { get; set; }
    public float OverallRating { get; set; }
    public string avatarFileName { get; set; }
    public List<Project> Projects { get; set; }
    public List<TaskModel> Tasks { get; set; }
    public List<Revenue> Revenues { get; set; }
}