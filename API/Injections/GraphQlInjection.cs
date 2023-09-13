using API.Mutations;
using API.Queries;

namespace API.Injections;

public static class GraphQlInjection
{
    public static void AddConfiguredGraphQl(this IServiceCollection services)
    {
        var server = services.AddGraphQLServer().ConfigureSchema(sb => sb.ModifyOptions(opts => opts.StrictValidation = false));

        server.AddQueryType<Query>();
        server.AddMutationType<UserMutation>();
        server.AddAuthorization();
    }
}