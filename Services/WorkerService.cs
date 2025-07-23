using BackOffice.Blazor.Models;

namespace BackOffice.Blazor.Services;

public interface IWorkerService
{
    Task<IEnumerable<Worker>> GetAllWorkersAsync();
    Task<Worker?> GetWorkerByIdAsync(int id);
    Task<Worker> CreateWorkerAsync(Worker worker);
    Task<Worker?> UpdateWorkerAsync(int id, Worker worker);
    Task<bool> DeleteWorkerAsync(int id);
}

public class WorkerService : IWorkerService
{
    // In-memory storage for demo purposes
    // In a real application, you would use Entity Framework or another data access layer
    private readonly List<Worker> _workers = new()
    {
        new Worker
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            PhoneNumber = "555-0101",
            DateOfBirth = new DateTime(1985, 5, 15),
            HireDate = new DateTime(2020, 3, 1),
            Position = "Home Care Assistant",
            HourlyRate = 25.00m,
            IsActive = true
        },
        new Worker
        {
            Id = 2,
            FirstName = "Jane",
            LastName = "Smith",
            Email = "jane.smith@example.com",
            PhoneNumber = "555-0102",
            DateOfBirth = new DateTime(1990, 8, 22),
            HireDate = new DateTime(2021, 6, 15),
            Position = "Senior Care Specialist",
            HourlyRate = 30.00m,
            IsActive = true
        }
    };

    public Task<IEnumerable<Worker>> GetAllWorkersAsync()
    {
        return Task.FromResult(_workers.AsEnumerable());
    }

    public Task<Worker?> GetWorkerByIdAsync(int id)
    {
        var worker = _workers.FirstOrDefault(w => w.Id == id);
        return Task.FromResult(worker);
    }

    public Task<Worker> CreateWorkerAsync(Worker worker)
    {
        worker.Id = _workers.Count > 0 ? _workers.Max(w => w.Id) + 1 : 1;
        _workers.Add(worker);
        return Task.FromResult(worker);
    }

    public Task<Worker?> UpdateWorkerAsync(int id, Worker worker)
    {
        var existingWorker = _workers.FirstOrDefault(w => w.Id == id);
        if (existingWorker == null)
            return Task.FromResult<Worker?>(null);

        existingWorker.FirstName = worker.FirstName;
        existingWorker.LastName = worker.LastName;
        existingWorker.Email = worker.Email;
        existingWorker.PhoneNumber = worker.PhoneNumber;
        existingWorker.DateOfBirth = worker.DateOfBirth;
        existingWorker.Position = worker.Position;
        existingWorker.HourlyRate = worker.HourlyRate;
        existingWorker.IsActive = worker.IsActive;
        existingWorker.Notes = worker.Notes;

        return Task.FromResult<Worker?>(existingWorker);
    }

    public Task<bool> DeleteWorkerAsync(int id)
    {
        var worker = _workers.FirstOrDefault(w => w.Id == id);
        if (worker == null)
            return Task.FromResult(false);

        _workers.Remove(worker);
        return Task.FromResult(true);
    }
}
