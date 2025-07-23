namespace BackOffice.Blazor.Models;

public class BillingRecord
{
    public int Id { get; set; }
    public int WorkerId { get; set; }
    public Worker? Worker { get; set; }
    public DateTime ServiceDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public decimal HoursWorked { get; set; }
    public decimal Rate { get; set; }
    public decimal TotalAmount { get; set; }
    public string ServiceType { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsBilled { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
