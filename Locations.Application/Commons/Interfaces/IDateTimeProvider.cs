namespace Locations.Application.Commons.Interfaces;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}