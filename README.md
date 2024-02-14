
# Simple Book Library Management System

This is a C# web application that allows users to manage books in a library. It uses Domain-Driven Design (DDD) and Clean Architecture principles to create a robust and maintainable software system.
It uses various interfaces and classes to query, List books, Checkout book and Return a Book from a database. It also uses a mapper and a logger to transform and log data. It returns different views depending on the request and the response status.

## Installation

To use this application, you need to have the following dependencies installed:

- .NET 7 or higher
- Entity Framework Core
- AutoMapper
- NLog
- PostgreSql

You can install them using the NuGet Package Manager or the dotnet CLI.


### Migrations
```bash
dotnet ef migrations add "InittialCreate" -p .\BookLibrary.WebApp\
dotnet ef database update -p .\BookLibrary.WebApp\


