namespace BackOffice.Blazor.Models;

public class Worker
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public DateTime HireDate { get; set; }
    public string Position { get; set; } = string.Empty;
    public decimal HourlyRate { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }
}
