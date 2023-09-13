
using Amazon.SimpleEmail;

namespace AWSApi.Injections;

public static class AwsInjection
{
    public static void AddAwsServices(this IServiceCollection services, IConfiguration configuration)
    {
        var awsOptions = configuration.GetAWSOptions();
        services.AddDefaultAWSOptions(awsOptions);
        services.AddAWSService<IAmazonSimpleEmailService>();
    }
}
