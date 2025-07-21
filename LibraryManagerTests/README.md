# Library Manager API Tests

## Prerequisites
- .NET SDK
- Visual Studio
- Place `LibraryManager.exe` in project root

## Running
```bash
dotnet test
```

## BDD
- Feature file: Features/LibraryManager.feature
- Steps: Steps/LibraryManagerSteps.cs, Steps/ServiceSteps.cs

## What it does
- Starts the service automatically before tests
- Stops it after tests
