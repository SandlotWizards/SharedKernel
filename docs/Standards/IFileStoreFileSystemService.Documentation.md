::RAG_SharedServiceDoc

## ServiceName
FileSystemService

## Interface
IFileStoreFileSystemService

## Namespace
SandlotWizards.ActionLogger.Interfaces.Windows

## Purpose
Provides access to the SoftwareFactory-managed file store, a persistent storage location used for specifications, templates, and structured project artifacts. This service resolves paths within a governed directory hierarchy, ensuring safe and valid file operations. It extends utility capabilities from `IUtilitityFileSystemService`.

## PublicAPI

- Method: `GetFileStoreRoot`
  - Parameters: none
  - Returns: `string` — root path to the FileStore (`UserProfile\SoftwareFactory\FileStore\SandlotWizards.SoftwareFactory.Specs`)

- Method: `LocateFileStoreFolder`
  - Parameters:
    - `folderName` (string): logical folder name
  - Returns: `string` — full path to a folder inside the FileStore

- Method: `LocateFileStoreFile`
  - Parameters:
    - `folderName` (string): subfolder name
    - `fileName` (string): name of the file
  - Returns: `string` — full path to the specified file in FileStore

- Method: `DirectoryExists`
  - Parameters:
    - `path` (string)
  - Returns: `bool` — whether the directory exists

- Method: `CreateDirectory`
  - Parameters:
    - `path` (string)
  - Returns: `void` — creates a directory at the specified path

- Method: `DeleteDirectory`
  - Parameters:
    - `path` (string)
    - `recursive` (bool, default: true)
  - Returns: `void` — deletes the directory if it exists

- Method: `EmptyDirectory`
  - Parameters:
    - `path` (string)
  - Returns: `void` — clears all files and folders within the path

- Method: `FileExists`
  - Parameters:
    - `path` (string)
  - Returns: `bool` — true if file exists at path

- Method: `WriteFileAsync`
  - Parameters:
    - `path` (string)
    - `content` (string)
    - `append` (bool, default: false)
  - Returns: `Task` — writes content to file asynchronously

- Method: `ReadFileAsync`
  - Parameters:
    - `path` (string)
  - Returns: `Task<string>` — content of the file as string

- Method: `DeleteFile`
  - Parameters:
    - `path` (string)
  - Returns: `void` — deletes file if exists

- Method: `CopyFile`
  - Parameters:
    - `source` (string)
    - `destination` (string)
    - `overwrite` (bool, default: true)
  - Returns: `void` — copies file from source to destination

- Method: `MoveFile`
  - Parameters:
    - `source` (string)
    - `destination` (string)
    - `overwrite` (bool, default: true)
  - Returns: `void` — moves file with optional overwrite

## Usage

Constructor injection example:
```csharp
private readonly IFileStoreFileSystemService _fileSystem;

public SpecStorageService(IFileStoreFileSystemService fileSystem)
{
    _fileSystem = fileSystem;
}
```

Used by components that generate, read, or manage specification documents, stored AI artifacts, or shared templates used across projects.

## DIRegistration

```csharp
services.AddSingleton<IFileStoreFileSystemService, FileSystemService>();
```

- Lifetime: Singleton
- Notes: Use when interacting with specification assets in a shared repository

## Constraints

- Ensures input folder and file names are non-null and non-empty
- Base directory is fixed to a governed path rooted in the user's profile
- All file/directory operations include inherited validation and safety
- Uses synchronous and asynchronous file APIs

## KnownConsumers

- AI design tools writing spec artifacts
- Feature generators accessing shared templates
- QA pipelines storing processed models or evaluations
