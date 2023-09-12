namespace Services.Services.Interfaces;

public interface IServices<T,P>
{
    Task<T> ExecuteAsync(P paramter );
}

public interface IServices<T>
{
    Task<T> ExecuteAsync();
}

