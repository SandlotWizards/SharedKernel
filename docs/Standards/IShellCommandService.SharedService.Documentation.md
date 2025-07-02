::RAG_SharedServiceDoc

## ServiceName
ShellCommandService

## Interface
IShellCommandService

## Namespace
SandlotWizards.ActionLogger.Interfaces.Windows

## Purpose
Executes shell commands using `System.Diagnostics.Process`, optionally capturing standard output and error. Used in command orchestration, CLI automation, and task execution services. Ensures command execution is encapsulated and testable through interface abstraction.

## PublicAPI

- Method: `ExecuteCommand`
  - Parameters:
    - `command` (string): the executable or command to run
    - `arguments` (string): command-line arguments
    - `workingDirectory` (string?, optional): the directory to run the command in
    - `captureOutput` (bool): if true, captures output and error streams
  - Returns: `int` — exit code from the executed process

- Property: `StandardOutput`
  - Type: `string?`
  - Purpose: Captured standard output from the last executed command
  - Nullable: Yes

- Property: `StandardError`
  - Type: `string?`
  - Purpose: Captured standard error from the last executed command
  - Nullable: Yes

## Usage

Injected via constructor:
```csharp
private readonly IShellCommandService _shellCommandService;

public MyService(IShellCommandService shellCommandService)
{
    _shellCommandService = shellCommandService;
}
```

Typical usage scenario:
- Used in command handler or CLI orchestration
- Called synchronously before branching logic or response handling

## DIRegistration

```csharp
services.AddSingleton<IShellCommandService, ShellCommandService>();
```

- Lifetime: Singleton (recommended)
- Register interface explicitly to promote abstraction

## Constraints

- Platform: Requires `System.Diagnostics.Process` — works on Windows, verify on Unix
- Behavior: Blocking/synchronous
- Caller must check `StandardError` after execution if `captureOutput = true`
- Does not throw on non-zero exit code — return value must be evaluated

## KnownConsumers

- `FeatureBuildService`
- `DeploymentRunnerCommand`
- Any orchestration service that executes shell tools or scripts
