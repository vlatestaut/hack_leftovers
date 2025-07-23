using BackOffice.Blazor.Models;
using BackOffice.Blazor.Services;

namespace BackOffice.Blazor.GraphQL;

public class Mutation
{
    /// <summary>
    /// Creates a new worker
    /// </summary>
    public async Task<Worker> CreateWorkerAsync(CreateWorkerInput input, [Service] IWorkerService workerService)
    {
        var worker = new Worker
        {
            FirstName = input.FirstName,
            LastName = input.LastName,
            Email = input.Email,
            PhoneNumber = input.PhoneNumber,
            DateOfBirth = input.DateOfBirth,
            HireDate = input.HireDate,
            Position = input.Position,
            HourlyRate = input.HourlyRate,
            IsActive = input.IsActive,
            Notes = input.Notes
        };

        return await workerService.CreateWorkerAsync(worker);
    }

    /// <summary>
    /// Updates an existing worker
    /// </summary>
    public async Task<Worker?> UpdateWorkerAsync(int id, UpdateWorkerInput input, [Service] IWorkerService workerService)
    {
        var worker = new Worker
        {
            FirstName = input.FirstName,
            LastName = input.LastName,
            Email = input.Email,
            PhoneNumber = input.PhoneNumber,
            DateOfBirth = input.DateOfBirth,
            Position = input.Position,
            HourlyRate = input.HourlyRate,
            IsActive = input.IsActive,
            Notes = input.Notes
        };

        return await workerService.UpdateWorkerAsync(id, worker);
    }

    /// <summary>
    /// Deletes a worker
    /// </summary>
    public async Task<bool> DeleteWorkerAsync(int id, [Service] IWorkerService workerService)
    {
        return await workerService.DeleteWorkerAsync(id);
    }
}

public record CreateWorkerInput(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    DateTime DateOfBirth,
    DateTime HireDate,
    string Position,
    decimal HourlyRate,
    bool IsActive = true,
    string? Notes = null
);

public record UpdateWorkerInput(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    DateTime DateOfBirth,
    string Position,
    decimal HourlyRate,
    bool IsActive = true,
    string? Notes = null
);
