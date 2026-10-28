# InventoryProjects

A collection of C# practice projects focused on inventory management and reusable code.

## Projects

- **IP1InventoryManagement** — An inventory management console application.
- **v44MiniProject** — A separate mini-project.
- **InventoryProjects.Common** — A class library containing shared classes and functionality used by the applications.

## Requirements

- Visual Studio with the .NET desktop development workload installed, or a compatible .NET SDK.
- A .NET SDK version compatible with the target framework (<TargetFramework>net10.0) specified in the project files.

## Getting Started

### 1. Download the repository

Clone the repository using Git:

```bash
git clone https://github.com/fyrgi/InventoryProjects/
```

Alternatively, download the repository as a ZIP file from GitHub and extract it.

**Download the entire repository**, including the solution file and all three project folders. Do not download an individual project folder by itself.

### 2. Open the solution

Open `InventoryProjects.slnx` in Visual Studio.
The solution contains both console applications and the shared class library.

### 3. Build the solution

In Visual Studio, select:

**Build → Build Solution**

Visual Studio will build the projects and their dependencies.

### 4. Run an application

Choose the application you want to run.

To run a project:

1. In Solution Explorer, right-click `v44MiniProject` or `IP1InventoryManagement`.
2. Select **Set as Startup Project**.
3. Press `Ctrl + F5` to run without debugging.

## Shared Code

The `InventoryProjects.Common` class library contains code shared between the applications.

The applications reference this library through project references. Keep the relative folder structure intact so these references continue to work after cloning or extracting the repository.

## Development Notes

- `bin` and `obj` are generated build folders and are not required in version control.
- Shared functionality belongs in `InventoryProjects.Common` when it is genuinely needed by multiple projects.
- Application-specific behavior belongs in the relevant application project.
- Each project has its relevant README.md with more specifications about the project and requirements.

## To Do
A Launcher.exe that can prompt the question which project does the user want to start.
