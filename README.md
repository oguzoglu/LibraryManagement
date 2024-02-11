
# Book Library Management System

This is a C# web application that allows users to manage books in a library. It uses Domain-Driven Design (DDD) and Clean Architecture principles to create a robust and maintainable software system.

## Installation

To use this application, you need to have the following dependencies installed:

- .NET 7 or higher
- Entity Framework Core
- AutoMapper
- NLog
- PostgreSql

You can install them using the NuGet Package Manager or the dotnet CLI. For example:


### Migrations
```bash
dotnet ef migrations add "InittialCreate" -p .\BookLibrary.WebApp\
dotnet ef database update -p .\BookLibrary.WebApp\


