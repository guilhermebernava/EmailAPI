
using Services.Dtos;

namespace Services.Services;

public interface IGetJobsServices
{
    Task<List<JobDto>> ExecuteAsync();
}
