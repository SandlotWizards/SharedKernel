::RAG_SharedServiceDoc

## ServiceName
FileSystemService

## Interface
IDeveloperFileSystemService

## Namespace
SandlotWizards.ActionLogger.Interfaces.Windows

## Purpose
Provides consistent access to developer-local source code and project directory structures. This service allows tools and automation processes to resolve paths to solutions, projects, source folders, and architecture documentation. It supports custom developer root overrides and enforces clean path composition. Inherits core file utilities from `IUtilitityFileSystemService`.

## PublicAPI

- Method: `GetDeveloperRootPath`
  - Parameters:
    - `rootOverride` (string, optional): alternate base directory path
  - Returns: `string` — developer root path, defaulting to `UserProfile\source\repos`

- Method: `LocateDeveloperSolutionPath`
  - Parameters:
    - `solution` (string): name of the solution folder
    - `rootOverride` (string, optional): base override
  - Returns: `string` — full path to the solution folder

- Method: `LocateDeveloperDotNetRoot`
  - Parameters:
    - `solution` (string): name of the solution
    - `rootOverride` (string, optional)
  - Returns: `string` — path to `src` under the solution folder

- Method: `LocateDeveloperProjectPath`
  - Parameters:
    - `solution` (string): solution name
    - `project` (string): project name
    - `rootOverride` (string, optional)
  - Returns: `string` — full path to the specific project folder  
  - Throws: `ArgumentException` if `solution` is null or whitespace

- Method: `GetArchitectureDocsPath`
  - Parameters:
    - `rootOverride` (string, optional)
  - Returns: `string` — path to Sandlot.ArchitectureDocs content project

- Method: `DirectoryExists`
  - Parameters:
    - `path` (string)
  - Returns: `bool` — whether the directory exists

- Method: `CreateDirectory`
  - Parameters:
    - `path` (string)
  - Returns: `void` — creates the directory

- Method: `DeleteDirectory`
  - Parameters:
    - `path` (string)
    - `recursive` (bool, default: true)
  - Returns: `void` — deletes the directory

- Method: `EmptyDirectory`
  - Parameters:
    - `path` (string)
  - Returns: `void` — clears all contents

- Method: `FileExists`
  - Parameters:
    - `path` (string)
  - Returns: `bool` — file existence check

- Method: `WriteFileAsync`
  - Parameters:
    - `path` (string)
    - `content` (string)
    - `append` (bool, default: false)
  - Returns: `Task` — writes to file asynchronously

- Method: `ReadFileAsync`
  - Parameters:
    - `path` (string)
  - Returns: `Task<string>` — reads file content

- Method: `DeleteFile`
  - Parameters:
    - `path` (string)
  - Returns: `void` — deletes the file

- Method: `CopyFile`
  - Parameters:
    - `source` (string)
    - `destination` (string)
    - `overwrite` (bool, default: true)
  - Returns: `void` — copies file

- Method: `MoveFile`
  - Parameters:
    - `source` (string)
    - `destination` (string)
    - `overwrite` (bool, default: true)
  - Returns: `void` — moves file

## Usage

Constructor injection example:
```csharp
private readonly IDeveloperFileSystemService _fileSystem;

public DevToolingService(IDeveloperFileSystemService fileSystem)
{
    _fileSystem = fileSystem;
}
```

Commonly used by tooling that manages or analyzes source code repositories, Visual Studio automation, or document generators.

## DIRegistration

```csharp
services.AddSingleton<IDeveloperFileSystemService, FileSystemService>();
```

- Lifetime: Singleton
- Notes: `rootOverride` allows for user-specific customization of developer workspace paths.

## Constraints

- Assumes Windows developer environment (uses `Environment.SpecialFolder.UserProfile`)
- Throws `ArgumentException` for invalid solution input
- All file operations inherit from `IUtilitityFileSystemService` and can have I/O side effects
- Mix of synchronous and asynchronous operations

## KnownConsumers

- Architecture document generators
- CLI source tooling commands
- AI project scaffolders
