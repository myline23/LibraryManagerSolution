# Library Manager API Tests

## Prerequisites
- .NET SDK
- Visual Studio
- Place `LibraryManager.exe` and 'LibraryManager.exe.config' in project root

## Running
-```bash
dotnet test
```
- from Test Explorer in Visual Studio run the tests 

## BDD
- Feature file: Features/LibraryManager.feature
- Steps: Steps/LibraryManagerSteps.cs, Steps/ServiceSteps.cs

## What it does
- Starts the service automatically before tests
- Stops it after tests
