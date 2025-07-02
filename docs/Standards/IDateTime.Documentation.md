::RAG_SharedServiceDoc

## ServiceName
DateTimeWrapper

## Interface
IDateTime

## Namespace
SandlotWizards.ActionLogger.Interfaces.Wrapper

## Purpose
Provides an abstraction over `System.DateTime` to support testability, consistency, and flexibility in retrieving the current time in both local and UTC formats. It also includes a standardized "null" sentinel value to represent uninitialized dates.

## PublicAPI

- Property: `Now`
  - Type: `DateTime`
  - Purpose: Gets the current local date and time
  - Nullable: No

- Property: `Today`
  - Type: `DateTime`
  - Purpose: Gets the current local date with time set to 00:00:00
  - Nullable: No

- Property: `Null`
  - Type: `DateTime`
  - Purpose: Returns a sentinel date value (January 1, 1800) to represent null or uninitialized dates
  - Nullable: No

- Property: `UtcNow`
  - Type: `DateTime`
  - Purpose: Gets the current UTC date and time
  - Nullable: No

## Usage

Constructor injection example:
```csharp
private readonly IDateTime _dateTime;

public MyService(IDateTime dateTime)
{
    _dateTime = dateTime;
}
```

Typical consumers include services or components that need to fetch current timestamps, calculate durations, log events with precise time references, or require a consistent date source for testability.

## DIRegistration

```csharp
services.AddSingleton<IDateTime, DateTimeWrapper>();
```

- Lifetime: Singleton
- Notes on when and how to register: Register as a singleton to ensure consistent time references across the application lifecycle and facilitate testing via mocking.

## Constraints

- Platform: .NET Standard / .NET Core / .NET 5+
- All access is synchronous and side-effect-free
- No external dependencies
- All return values are system-generated and assumed valid unless the system clock is misconfigured

## KnownConsumers

- Logging frameworks (e.g., ActionLogger)
- Time-sensitive domain services
- Scheduled task utilities
- Test suites requiring controlled time injection
