using Locations.Application.Commons.Interfaces;

namespace Locations.Infrastructure.Providers.Commons
{
    public class SystemDateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}