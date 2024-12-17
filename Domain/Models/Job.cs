namespace Domain.Models;

public class Job
{
    public int JobId { get; set; }
    public int EmployerId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Salary { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}