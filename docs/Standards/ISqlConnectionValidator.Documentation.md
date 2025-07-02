::RAG_SharedServiceDoc

## ServiceName
SqlConnectionValidator

## Interface
ISqlConnectionValidator

## Namespace
SandlotWizards.ActionLogger.Interfaces.Sql

## Purpose
The `SqlConnectionValidator` service provides a simple abstraction for verifying SQL database connectivity and executing raw SQL commands. It helps determine whether a given connection string is valid and facilitates running SQL commands directly against a target database.

## PublicAPI

- Method: `CanConnectAsync`
  - Parameters:
    - `connectionString` (string): The connection string used to connect to the SQL database.
    - `ct` (CancellationToken): Token for cancelling the asynchronous operation.
  - Returns: `Task<bool>` - Returns true if the connection opens successfully, otherwise false.

- Method: `ExecuteRawSqlAsync`
  - Parameters:
    - `connectionString` (string): The connection string used to connect to the SQL database.
    - `sql` (string): The raw SQL command to be executed.
    - `ct` (CancellationToken): Token for cancelling the asynchronous operation.
  - Returns: `Task` - Completes when the SQL command has finished executing.

## Usage

Constructor injection example:
```csharp
private readonly ISqlConnectionValidator _sqlConnectionValidator;

public MyService(ISqlConnectionValidator sqlConnectionValidator)
{
    _sqlConnectionValidator = sqlConnectionValidator;
}
```

This service would typically be consumed by features that need to verify SQL database availability or run direct SQL commands for diagnostics, setup, or maintenance.

## DIRegistration

```csharp
services.AddSingleton<ISqlConnectionValidator, SqlConnectionValidator>();
```

- Lifetime: Singleton
- Notes on when and how to register: Register at application startup for use in any component that needs to validate SQL connections or perform ad-hoc SQL execution.

## Constraints

- Platform: .NET with Microsoft.Data.SqlClient
- Async: All operations are asynchronous
- Side effects: Opens connections and executes SQL commands; proper handling of exceptions is required
- Return value validation: `CanConnectAsync` returns `false` on exception, ensuring graceful failure.

## KnownConsumers

- ActionLogger setup tools
- Diagnostics or health-check modules
- Deployment or configuration utilities that test DB connectivity
