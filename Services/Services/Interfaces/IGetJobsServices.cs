namespace Services.Services;

public interface IGetJobsServices
{
    Task<List<string>> ExecuteAsync();
}
