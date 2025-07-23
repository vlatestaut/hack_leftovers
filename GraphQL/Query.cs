using BackOffice.Blazor.Models;
using BackOffice.Blazor.Services;

namespace BackOffice.Blazor.GraphQL;

public class Query
{
    /// <summary>
    /// Gets all workers in the system
    /// </summary>
    public async Task<IEnumerable<Worker>> GetWorkersAsync([Service] IWorkerService workerService)
    {
        return await workerService.GetAllWorkersAsync();
    }

    /// <summary>
    /// Gets a specific worker by ID
    /// </summary>
    public async Task<Worker?> GetWorkerAsync(int id, [Service] IWorkerService workerService)
    {
        return await workerService.GetWorkerByIdAsync(id);
    }

    /// <summary>
    /// Gets active workers only
    /// </summary>
    public async Task<IEnumerable<Worker>> GetActiveWorkersAsync([Service] IWorkerService workerService)
    {
        var workers = await workerService.GetAllWorkersAsync();
        return workers.Where(w => w.IsActive);
    }
}
