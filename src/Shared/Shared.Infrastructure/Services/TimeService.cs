namespace Shared.Infrastructure;

internal class TimeService : ITimeService
{
    public DateTime CurrentDate() => DateTime.UtcNow;
}
