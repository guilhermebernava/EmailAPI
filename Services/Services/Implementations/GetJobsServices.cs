using Hangfire;
using Hangfire.Storage;

namespace Services.Services;

public class GetJobsServices : IGetJobsServices
{
    private readonly IStorageConnection _connection;

    public GetJobsServices()
    {
        _connection = JobStorage.Current.GetConnection();
    }

  
    public async Task<List<string>> ExecuteAsync()
    {
        var recurringJobs = new List<string>();
        var recurringJobEntries = _connection.GetRecurringJobs();

        await Task.Run(() =>
        {
            foreach (var recurringJobEntry in recurringJobEntries)
            {
                recurringJobs.Add(recurringJobEntry.Id);
            }
        });

        return recurringJobs;
    }
}
