namespace DashboardApi.Models;

public class TaskDTO
{
    public string Id { get; set; }
    public bool IsCompleted { get; set; }
    public string Title { get; set; }
    public DateTime Deadline { get; set; }
    public List<TaskStep> Steps { get; set; }
    public List<Comment> Comments { get; set; }
    public string Priority { get; set; }
}