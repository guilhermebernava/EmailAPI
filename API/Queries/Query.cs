using HotChocolate.Authorization;

namespace API.Queries;

public class Query
{
    [Authorize]
    public async Task<bool> Test()
    {
        return true;
    }
}
