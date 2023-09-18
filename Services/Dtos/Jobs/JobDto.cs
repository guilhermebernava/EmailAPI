namespace Services.Dtos;

public class JobDto
{
    public JobDto()
    {
        
    }
    public JobDto(string name, string cron, string method, string queue)
    {
        Name = name;
        Cron = cron;
        Method = method;
        Queue = queue;
    }

    public string Name { get; set; }
    public string Cron { get; set; }
    public string Method { get; set; }
    public string Queue { get; set; }
}
