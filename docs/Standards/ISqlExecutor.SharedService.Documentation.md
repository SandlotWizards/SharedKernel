::RAG_SharedServiceDoc

## ServiceName
SqlExecutor

## Interface
ISqlExecutor

## Namespace
SandlotWizards.ActionLogger.Interfaces.Sql

## Purpose
Executes raw SQL commands or reads values from specific columns in a result set using a named connection string. Useful for dynamic or administrative database operations where the query logic is provided at runtime.

## PublicAPI

- Method: `ExecuteAsync`
  - Parameters:
    - `connectionKey` (string): The key used to identify the connection string in a dictionary.
    - `sql` (string): The SQL command to execute.
    - `ct` (CancellationToken): A token to monitor for cancellation requests.
  - Returns: `Task` — Executes a non-query SQL command (e.g., INSERT, UPDATE, DELETE).

- Method: `ExecuteReaderAsync`
  - Parameters:
    - `connectionKey` (string): The key used to identify the connection string in a dictionary.
    - `sql` (string): The SELECT query to execute.
    - `columnName` (string): The column from which to extract results.
    - `ct` (CancellationToken): A token to monitor for cancellation requests.
  - Returns: `Task<IEnumerable<string>>` — A list of values from the specified column in the result set.

## Usage

Constructor injection example:
```csharp
private readonly ISqlExecutor _sqlExecutor;

public MyService(ISqlExecutor sqlExecutor)
{
    _sqlExecutor = sqlExecutor;
}
```

Typically consumed by services or command handlers needing to run dynamic SQL queries or data extract routines without relying on EF or strongly-typed ORMs.

## DIRegistration

```csharp
services.AddSingleton<ISqlExecutor, SqlExecutor>();
```

- Lifetime: Singleton
- Notes on when and how to register: Register at application startup where a shared, thread-safe SQL execution mechanism is needed across services. Requires a populated connection string dictionary and logging configuration.

## Constraints

- Platform: .NET 6+ using `Microsoft.Data.SqlClient`.
- Async: Fully asynchronous methods using `async/await`.
- Side effects: Executes raw SQL commands that may modify data or schema.
- Return value validation: No schema validation or column existence checks — assumes caller provides correct SQL and column names.
- Throws `ArgumentException` if connection key is not found.

## KnownConsumers

- Feature orchestration services requiring raw SQL execution
- Command processors for database migration, data patching, or auditing
- Dynamic RAG or logging systems persisting AI context
