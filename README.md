# SandlotWizards.SharedKernel

**Version**: 2.0.0  
**Target Framework**: .NET 8.0  
**License**: MIT  
**Author**: Sandlot Wizards  
**Repository**: [SandlotWizards/Sandlot.ActionLogger](https://github.com/SandlotWizards/Sandlot.ActionLogger)  

## Overview

**SandlotWizards.SharedKernel** is a structured, scoped, and AI-friendly shared kernel for .NET applications. It is designed to provide foundational utilities for consistent logging, validation, configuration, file system interaction, Redis caching, command execution, and more — with support for AI integration and OpenTelemetry observability.

This library is intended for internal reuse across multiple microservices or modules, providing a unified programming model and reducing redundant code.

---

## Features

- ✅ Strong separation of interfaces and implementations  
- ✅ Built-in support for AI service hooks  
- ✅ Redis and file system abstractions  
- ✅ Structured logging with Serilog + OpenTelemetry  
- ✅ Ready-to-use helper utilities and constants  
- ✅ Designed for RAG-based (Retrieval-Augmented Generation) integration  

---

## Installation

Install via NuGet:

```bash
dotnet add package SandlotWizards.SharedKernel
```

---

## Namespaces and Capabilities

### `SandlotWizards.SharedKernel.Configuration`

- **GitHubConfig**: Represents settings for integrating GitHub repository metadata, such as branch, repo, and user context.

---

### `SandlotWizards.SharedKernel.Constants`

- **LoggingConstants**: Standardized log message templates.
- **RegularExpressions**: Common reusable regex patterns (e.g., GUID format).

---

### `SandlotWizards.SharedKernel.Enums`

- **EfCoreTargetType**: Specifies how EF Core targets are resolved (e.g., `SqlServer`, `PostgreSql`).
- **FormMode**: Distinguishes between `Create`, `Update`, and `Delete` forms.

---

### `SandlotWizards.SharedKernel.Helpers`

- **FormatProperties**: A reflection-based helper that extracts and formats object properties into key-value pairs for telemetry, logging, or diagnostics.

---

### `SandlotWizards.SharedKernel.Interfaces`

#### Common Service Interfaces

- **IAiService**  
  Defines contract for AI operations using natural language input/output.

- **ICommandHandler**  
  Defines a generalized `ExecuteAsync` pattern for command handling.

- **IRedisCacheService**  
  Abstracts Redis interactions such as storing, retrieving, and deleting cache entries.

- **IShellCommandService**  
  Provides shell command execution support with stdout/stderr capture.

- **ISqlConnectionValidator**  
  Validates connectivity for a provided SQL connection string.

- **ISqlExecutor**  
  Encapsulates SQL command execution, both scalar and result-based.

#### File System Service Interfaces

- **IDeploymentFileSystemService**  
  Encapsulates filesystem operations for deployment automation.

- **IDeveloperFileSystemService**  
  Filesystem services for developer tooling.

- **IFileStoreFileSystemService**  
  Generic abstraction for storing and retrieving structured data from the filesystem.

- **ISoftwareFactoryWorkingFileSystemService**  
  Specialized file service interface supporting working file operations in AI-driven software factories.

#### Miscellaneous

- **IDateTime**  
  Provides testable access to `Now`, `UtcNow`, and `Today`.

- **IValidationResult**  
  Defines standard structure for validation results used across services.

---

## Usage Example

Here's a basic example using the `IRedisCacheService`:

```csharp
public class UserCacheManager
{
    private readonly IRedisCacheService _redis;

    public UserCacheManager(IRedisCacheService redis)
    {
        _redis = redis;
    }

    public async Task CacheUserAsync(string id, UserModel user)
    {
        await _redis.SetAsync(id, user, TimeSpan.FromMinutes(30));
    }

    public Task<UserModel?> GetUserAsync(string id)
    {
        return _redis.GetAsync<UserModel>(id);
    }
}
```

---

## Telemetry & Logging

Integrated with **Serilog** + **OpenTelemetry**:

- Console
- Environment enrichment
- Optional ElasticSearch sink

All log messages are strongly typed via `LoggingConstants` to encourage consistency.

---

## Documentation

Detailed service documentation and RAG-ready prompts are available in the `docs/Standards/` directory of the repository.

---

## Contributing

We welcome contributions! Please open issues or pull requests with improvements or fixes. Make sure to follow the design and interface standards defined in this shared kernel.

---

## License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).
