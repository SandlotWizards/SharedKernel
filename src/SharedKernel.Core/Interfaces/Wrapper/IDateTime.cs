using System;

namespace SandlotWizards.ActionLogger.Interfaces.Wrapper
{
    public interface IDateTime
    {
        DateTime Now { get; }
        DateTime Null { get; }
        DateTime UtcNow { get; }
    }
}