using Hangfire;
using Hangfire.Storage;
using Services.Dtos;

namespace Services.Services;

public class GetJobsServices : IGetJobsServices
{
    private readonly IStorageConnection _connection;

    public GetJobsServices()
    {
        _connection = JobStorage.Current.GetConnection();
    }

  
    public async Task<List<JobDto>> ExecuteAsync()
    {
        var recurringJobs = new List<JobDto>();
        var recurringJobEntries = _connection.GetRecurringJobs();

        await Task.Run(() =>
        {
            foreach (var recurringJobEntry in recurringJobEntries)
            {
                var jobInfo = new JobDto()
                {
                    Name = recurringJobEntry.Id,
                    Cron = recurringJobEntry.Cron,
                    Method = recurringJobEntry.Job.Method.Name,
                    Queue = recurringJobEntry.Queue
                };

                recurringJobs.Add(jobInfo);
            }
        });

        return recurringJobs;
    }
}
