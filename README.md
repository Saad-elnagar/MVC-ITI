# MVC-ITI — ASP.NET Core MVC Practice Project

[![Build](https://github.com/Saad-elnagar/MVC-ITI/actions/workflows/dotnet-build.yml/badge.svg?branch=master)](https://github.com/Saad-elnagar/MVC-ITI/actions/workflows/dotnet-build.yml)

An ASP.NET Core MVC application used to practice MVC workflows, Entity Framework Core, relational data, view models, and SQL Server integration.

## Features

- MVC controllers and Razor views for courses, instructors, and products.
- Create, edit, list, and details workflows across the main entities.
- View models to shape data passed between controllers and views.
- EF Core DbContexts and migrations for the application's database contexts.
- SQL Server integration.
- Pagination view-model structure and server-side form validation support.
- Docker-related project files for learning containerized application setup.

## Tech Stack

- C# and .NET 10
- ASP.NET Core MVC
- Entity Framework Core (SQL Server provider)
- SQL Server
- Razor Views and Bootstrap

## Solution Structure

```text
MVC_3Tir/
  Controllers/    MVC endpoints
  DataBase/       AppDbContext and ECDbContext
  Models/         Domain models
  VM/             View models for UI workflows
  Migrations/     EF Core migrations
  Views/          Razor pages for Course, Instructor, Product, and shared layouts
  wwwroot/        Static assets
```

## Prerequisites

- .NET 10 SDK
- SQL Server
- The .NET EF Core CLI tool if you need to apply migrations

## Configure the Database

The app reads two connection strings: `ConnectionStrings:DefaultConnection` and `ConnectionStrings:EcommerceConnection`.

Set local values with .NET User Secrets. From the repository root:

```bash
dotnet user-secrets init --project "MVC_3Tir/MVC_3Tir.csproj"
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "YOUR_MAIN_DATABASE_CONNECTION_STRING" --project "MVC_3Tir/MVC_3Tir.csproj"
dotnet user-secrets set "ConnectionStrings:EcommerceConnection" "YOUR_ECOMMERCE_DATABASE_CONNECTION_STRING" --project "MVC_3Tir/MVC_3Tir.csproj"
```

Do not commit database passwords or machine-specific connection strings.

## Run Locally

From the repository root:

```bash
dotnet restore "MVC_ ITI .sln"
dotnet run --project "MVC_3Tir/MVC_3Tir.csproj"
```

If the database has not been created yet, apply the migrations for the relevant context:

```bash
dotnet ef database update --project "MVC_3Tir/MVC_3Tir.csproj" --startup-project "MVC_3Tir/MVC_3Tir.csproj" --context AppDbContext
dotnet ef database update --project "MVC_3Tir/MVC_3Tir.csproj" --startup-project "MVC_3Tir/MVC_3Tir.csproj" --context ECDbContext
```

## Learning Focus

This repository is primarily a learning project demonstrating MVC request handling, model binding, view models, EF Core data access, migrations, and CRUD-oriented UI workflows.
