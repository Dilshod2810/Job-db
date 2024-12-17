namespace Domain.Models;

public class Application
{
    public int ApplicationId { get; set; }
    public int JobId { get; set; }
    public int ApplicantId { get; set; }
    public string Resume { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}