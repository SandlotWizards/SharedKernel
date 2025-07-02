# RAG Shared Service Documentation Instruction

You are generating markdown documentation for a shared service in a .NET codebase.

You will be given:
- The interface (e.g., IShellCommandService)
- The implementation class (e.g., ShellCommandService)

Your job is to generate a single markdown file that documents the service in a structured way, so that other AI systems (using RAG) can accurately generate code that depends on it.

## Output Format

Use the following sections and formatting.

---

::RAG_SharedServiceDoc

## ServiceName
[Name of the implementation class]

## Interface
[Name of the interface]

## Namespace
[Namespace of the interface]

## Purpose
A single paragraph describing what the service does and why it exists.

## PublicAPI

List all public methods and properties.

- Method: `MethodName`
  - Parameters:
    - `param1` (type): description
    - ...
  - Returns: return type and description

- Property: `PropertyName`
  - Type: `type`
  - Purpose: what it provides
  - Nullable: Yes/No

## Usage

Constructor injection example:
```csharp
private readonly IInterfaceName _service;

public MyService(IInterfaceName service)
{
    _service = service;
}
```

State what kind of services or commands would typically consume this.

## DIRegistration

```csharp
services.AddSingleton<IInterfaceName, ImplementationClass>();
```

- Lifetime: Singleton/Scoped/Transient
- Notes on when and how to register

## Constraints

Mention platform, sync/async, side effects, return value validation, etc.

## KnownConsumers

List common services, features, or commands that use this service.

---

Only output the final markdown. Do not include explanation or commentary.
