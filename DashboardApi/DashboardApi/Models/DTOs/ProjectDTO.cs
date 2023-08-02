namespace DashboardApi.Models;

public class ProjectDTO
{

    public string Id { get; set; }
    public DateTime StartDate { get; set; }
    public string Title { get; set; }
    public string Stage { get; set; }
    public string Description { get; set; }
    public byte Progress { get; set; }
    public List<ProjectMember> ProjectMembers { get; set; }
}