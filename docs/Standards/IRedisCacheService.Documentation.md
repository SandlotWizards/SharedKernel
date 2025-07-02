::RAG_SharedServiceDoc

## ServiceName
RedisCacheService

## Interface
IRedisCacheService

## Namespace
SandlotWizards.ActionLogger.Interfaces.Redis

## Purpose
The `RedisCacheService` provides asynchronous methods for storing, retrieving, checking, and deleting objects in a distributed Redis cache using `IDistributedCache` as the underlying storage mechanism. It simplifies interaction with the Redis cache by abstracting serialization and expiration logic, making it easier for services to implement caching.

## PublicAPI

- Method: `SetAsync<T>`
  - Parameters:
    - `key` (string): The Redis key under which the value is stored
    - `value` (T): The object to store
    - `ttl` (TimeSpan?, optional): Time-to-live for the cache entry
    - `cancellationToken` (CancellationToken, optional): Cancellation control
  - Returns: `Task` - Represents the asynchronous cache write operation

- Method: `SetAsync<T>`
  - Parameters:
    - `key` (string): The Redis key
    - `value` (T): The object to store
    - `cancellationToken` (CancellationToken): Cancellation control
  - Returns: `Task` - Overload with no TTL

- Method: `GetAsync<T>`
  - Parameters:
    - `key` (string): Redis key for the item
    - `cancellationToken` (CancellationToken, optional): Cancellation control
  - Returns: `Task<T?>` - The deserialized value or null if not found

- Method: `ExistsAsync`
  - Parameters:
    - `key` (string): The key to check
    - `cancellationToken` (CancellationToken, optional): Cancellation control
  - Returns: `Task<bool>` - True if key exists, false otherwise

- Method: `DeleteAsync`
  - Parameters:
    - `key` (string): The key to delete
    - `cancellationToken` (CancellationToken, optional): Cancellation control
  - Returns: `Task` - Represents the asynchronous cache removal

## Usage

Constructor injection example:
```csharp
private readonly IRedisCacheService _cacheService;

public MyService(IRedisCacheService cacheService)
{
    _cacheService = cacheService;
}
```

This service would typically be consumed by application services, orchestrators, or feature modules that require high-speed storage and retrieval of transient data such as command states, API responses, or feature toggles.

## DIRegistration

```csharp
services.AddSingleton<IRedisCacheService, RedisCacheService>();
```

- Lifetime: Singleton
- Notes: Register once at startup. `IDistributedCache` must already be configured in the DI container (e.g., `AddStackExchangeRedisCache`).

## Constraints

- Platform: .NET
- All operations are asynchronous.
- Serialization is handled using `System.Text.Json`.
- Default TTL is 6 hours unless overridden.
- If the key is missing or expired, `GetAsync` returns `null`.
- No logging, exception handling, or retry logic is baked into this service—those responsibilities are delegated to consumers.

## KnownConsumers

- Logging and telemetry processors
- Feature orchestration services
- Command execution frameworks
- AI pipeline or cache-sensitive utilities
