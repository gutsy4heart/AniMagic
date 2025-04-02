using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Application.DTOs.Cartoon;

public class AddFavoriteDto
{
    public required Guid CartoonId { get; set; }
}



/*
 
 AniMagic/
│-- AniMagic.Api/              # (Presentation Layer - API)
│   ├── Controllers/           # API Endpoints (Auth, Cartoons, Users, etc.)
│   ├── Middlewares/           # Custom middleware (e.g., JWT authentication)
│   ├── Program.cs             # Entry point for the API
│   ├── appsettings.json       # Configuration (Database, JWT, etc.)
│
│-- AniMagic.Application/      # (Application Layer - Business Logic)
│   ├── Services/              # Business logic for authentication, users, cartoons, etc.
│   ├── DTOs/                  # Data Transfer Objects (DTOs)
│   ├── Interfaces/            # Contracts for services
│
│-- AniMagic.Contracts/        # (Contracts Layer - API Contracts)
│   ├── Requests/              # Request DTOs for API calls
│   ├── Responses/             # Response DTOs for API calls
│
│-- AniMagic.Domain/           # (Domain Layer - Core Business Models)
│   ├── Entities/              # Database entities (User, Cartoon, Comment, etc.)
│   ├── Models/                # Domain-specific logic and value objects
│   ├── Interfaces/            # Repository interfaces
│
│-- AniMagic.Infrastructure/   # (Infrastructure Layer - Database & Security)
│   ├── Data/                  # Database Context, Migrations, Seeding
│   ├── Repositories/          # Implementation of Repositories
│   ├── Helpers/               # JWT Token Generator, Password Hasher
│
│-- README.md                  # Documentation
│-- .gitignore                 # Git Ignore
 
 
 */