::RAG_SharedServiceDoc

## ServiceName
FileSystemService

## Interface
ISoftwareFactoryWorkingFileSystemService

## Namespace
SandlotWizards.ActionLogger.Interfaces.Windows

## Purpose
Provides structured access to the SoftwareFactory working directory used by pipeline runners and AI tools. Supports operations for creating unique runner contexts and navigating standardized folder structures like `repos`, `docs`, `src`, and `tests`. Designed for use in orchestrated pipelines that operate on temporary working folders for cloning, building, analyzing, or transforming repositories. Inherits I/O utilities from `IUtilitityFileSystemService`.

## PublicAPI

- Method: `GetSoftwareFactoryWorkingRoot`
  - Parameters: none
  - Returns: `string` — root path for all working operations (`UserProfile\SoftwareFactory\Working`)

- Method: `GetSoftwareFactoryRunnerPath`
  - Parameters:
    - `runner` (string): unique runner ID
  - Returns: `string` — path to runner-specific root

- Method: `CreateSoftwareFactoryWorkingRunner`
  - Parameters: none
  - Returns: `string` — creates and returns new unique runner ID (also creates directory)

- Method: `LocateSoftwareFactoryWorkingRepoPath`
  - Parameters:
    - `runner` (string)
    - `repoName` (string)
  - Returns: `string` — path to `repos/<repoName>` under given runner

- Method: `LocateSoftwareFactoryWorkingProjectPath`
  - Parameters:
    - `runner` (string)
    - `repoName` (string)
    - `project` (string)
  - Returns: `string` — full path to `src/<project>` under runner's repo

- Method: `LocateSoftwareFactoryWorkingDocsPath`
  - Parameters:
    - `runner` (string)
    - `repoName` (string)
  - Returns: `string` — path to `docs` under repo

- Method: `LocateSoftwareFactoryWorkingSrcPath`
  - Parameters:
    - `runner` (string)
    - `repoName` (string)
  - Returns: `string` — path to `src` under repo

- Method: `LocateSoftwareFactoryWorkingTestsPath`
  - Parameters:
    - `runner` (string)
    - `repoName` (string)
  - Returns: `string` — path to `tests` under repo

- Method: `DirectoryExists`
  - Parameters:
    - `path` (string)
  - Returns: `bool` — true if directory exists

- Method: `CreateDirectory`
  - Parameters:
    - `path` (string)
  - Returns: `void` — creates the directory if not exists

- Method: `DeleteDirectory`
  - Parameters:
    - `path` (string)
    - `recursive` (bool, default: true)
  - Returns: `void` — deletes the directory

- Method: `EmptyDirectory`
  - Parameters:
    - `path` (string)
  - Returns: `void` — removes all files/subfolders

- Method: `FileExists`
  - Parameters:
    - `path` (string)
  - Returns: `bool` — checks for file presence

- Method: `WriteFileAsync`
  - Parameters:
    - `path` (string)
    - `content` (string)
    - `append` (bool, default: false)
  - Returns: `Task` — writes asynchronously

- Method: `ReadFileAsync`
  - Parameters:
    - `path` (string)
  - Returns: `Task<string>` — reads contents of file

- Method: `DeleteFile`
  - Parameters:
    - `path` (string)
  - Returns: `void` — deletes file if present

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
private readonly ISoftwareFactoryWorkingFileSystemService _fileSystem;

public RunnerService(ISoftwareFactoryWorkingFileSystemService fileSystem)
{
    _fileSystem = fileSystem;
}
```

Used by AI pipelines, feature design engines, and orchestrators that interact with cloned repositories, runner-specific states, or isolated transformations.

## DIRegistration

```csharp
services.AddSingleton<ISoftwareFactoryWorkingFileSystemService, FileSystemService>();
```

- Lifetime: Singleton
- Notes: Must be registered to enable consistent working path access across runners

## Constraints

- Uses `Guid.NewGuid()` to generate isolated working folders
- All inputs validated against null/empty for safety
- Heavy I/O operation role; should not be used in memory-constrained environments without pruning
- Paths are user-profile scoped and OS-specific (Windows)

## KnownConsumers

- FeatureBuildService
- EngageAiWorkerAsync
- WorkingRepo staging tools
