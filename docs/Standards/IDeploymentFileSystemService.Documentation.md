::RAG_SharedServiceDoc

## ServiceName
FileSystemService

## Interface
IDeploymentFileSystemService

## Namespace
SandlotWizards.ActionLogger.Interfaces.Windows

## Purpose
Provides standardized file system access to deployment-related directory structures. This service ensures consistent resolution of deployment repository paths across environments such as local development and remote targets, enforcing input validation and structured path conventions. It extends utility capabilities from `IUtilitityFileSystemService`, combining them with SoftwareFactory deployment policies.

## PublicAPI

- Method: `LocateDeploymentRepoPath`
  - Parameters:
    - `environment` (string): name of the environment (e.g., "localhost", "dev", "prod")
    - `profile` (string, optional): deployment profile, required for "localhost"
  - Returns: `string` — root path for environment deployment repository

- Method: `LocateDeploymentRepoPath`
  - Parameters:
    - `environment` (string): target environment
    - `solution` (string): solution name
    - `profile` (string, optional): required only for "localhost"
  - Returns: `string` — path to the deployed solution directory

- Method: `LocateDeploymentRepoPath`
  - Parameters:
    - `environment` (string): target environment
    - `solution` (string): solution name
    - `project` (string): project name
    - `profile` (string, optional): required only for "localhost"
  - Returns: `string` — path to the deployed project directory

- Method: `DirectoryExists`
  - Parameters:
    - `path` (string): path to check
  - Returns: `bool` — whether the directory exists

- Method: `CreateDirectory`
  - Parameters:
    - `path` (string): path to create
  - Returns: `void` — creates the specified directory

- Method: `DeleteDirectory`
  - Parameters:
    - `path` (string): path to delete
    - `recursive` (bool, default: true): whether to delete recursively
  - Returns: `void` — deletes the directory if it exists

- Method: `EmptyDirectory`
  - Parameters:
    - `path` (string): path to empty
  - Returns: `void` — removes all files and subdirectories from the path

- Method: `FileExists`
  - Parameters:
    - `path` (string): file path
  - Returns: `bool` — whether the file exists

- Method: `WriteFileAsync`
  - Parameters:
    - `path` (string): path to write
    - `content` (string): content to write
    - `append` (bool, default: false): whether to append
  - Returns: `Task` — writes to the file asynchronously

- Method: `ReadFileAsync`
  - Parameters:
    - `path` (string): file path
  - Returns: `Task<string>` — contents of the file

- Method: `DeleteFile`
  - Parameters:
    - `path` (string): file path
  - Returns: `void` — deletes the file if it exists

- Method: `CopyFile`
  - Parameters:
    - `source` (string): source file
    - `destination` (string): destination file
    - `overwrite` (bool, default: true): whether to overwrite
  - Returns: `void` — copies the file

- Method: `MoveFile`
  - Parameters:
    - `source` (string): original path
    - `destination` (string): new path
    - `overwrite` (bool, default: true): whether to overwrite
  - Returns: `void` — moves the file, deleting the target if needed

## Usage

Constructor injection example:
```csharp
private readonly IDeploymentFileSystemService _fileSystem;

public DeploymentManager(IDeploymentFileSystemService fileSystem)
{
    _fileSystem = fileSystem;
}
```

Typically consumed by:
- Deployment orchestration services
- CLI commands that interact with file systems
- Build, deployment, and AI inference workflows

## DIRegistration

```csharp
services.AddSingleton<IDeploymentFileSystemService, FileSystemService>();
```

- Lifetime: Singleton
- Notes: This interface enforces correct access to deployment folders by applying profile and environment validation logic.

## Constraints

- Validates `environment` and `profile` combinations: 
  - `"localhost"` requires a non-null profile.
  - Other environments require `profile` to be null.
- Synchronous and asynchronous I/O operations
- Throws `ArgumentException` for invalid inputs
- Windows paths with hardcoded base for deployment roots (`C:\Solution_Deployments`)

## KnownConsumers

- Deployment pipeline coordinators
- Command-line deployment tools
- Environment provisioning scripts
