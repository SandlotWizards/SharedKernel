using System;

namespace SandlotWizards.SharedKernel.Interfaces.Wrapper
{
    public interface IDateTime
    {
        DateTime Now { get; }
        DateTime Null { get; }
        DateTime UtcNow { get; }
    }
}