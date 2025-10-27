# 🎮 GameStore Backend API

A modern RESTful API backend for managing a video game store catalog, built with ASP.NET Core 9.0 using Minimal APIs and Entity Framework Core.

## 📋 Overview

GameStore Backend is a lightweight and efficient API that provides complete CRUD (Create, Read, Update, Delete) operations for managing video game information. The application follows clean architecture principles with a repository pattern and uses SQL Server for data persistence.

## ✨ Features

- **RESTful API Endpoints** - Full CRUD operations for games and genres
- **Entity Framework Core** - Database migrations and SQL Server integration
- **Data Validation** - Request validation using Data Annotations
- **Repository Pattern** - Clean separation of concerns with abstracted data access
- **Minimal APIs** - Modern ASP.NET Core minimal API approach for better performance
- **DTOs** - Separate Data Transfer Objects for API requests and responses

## 🛠️ Technology Stack

- **.NET 9.0** - Latest .NET framework
- **ASP.NET Core** - Web API framework
- **Entity Framework Core 9.0.6** - ORM for database operations
- **SQL Server** - Relational database
- **MinimalApis.Extensions** - Enhanced minimal API functionality

## 📁 Project Structure

```
GameStore-Backend/
├── GameStore.Api/
│   ├── Data/                    # Database context and data extensions
│   │   ├── GameStoreContext.cs
│   │   ├── DataExtensions.cs
│   │   └── Migrations/
│   ├── DTOs/                    # Data Transfer Objects
│   │   └── DTOs.cs
│   ├── Endpoints/               # API endpoint definitions
│   │   ├── GamesEndpoints.cs
│   │   └── GenreEndpoints.cs
│   ├── Entities/                # Domain models
│   │   ├── Game.cs
│   │   ├── Genre.cs
│   │   └── EntityExtensions.cs
│   ├── Repositories/            # Data access layer
│   │   ├── IGamesRepository.cs
│   │   └── EntitFrameworkGamesRepo.cs
│   └── Program.cs               # Application entry point
└── GameStoreBackend.sln
```

## 🚀 Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express or higher)
- A code editor (Visual Studio 2022, VS Code, or Rider)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/PuneetVerma04/GameStore-Backend.git
   cd GameStore-Backend
   ```

2. **Configure the database connection**
   
   Update the connection string in `appsettings.json` or use User Secrets:
   ```bash
   dotnet user-secrets set "ConnectionStrings:GameStoreDb" "YOUR_CONNECTION_STRING"
   ```

3. **Apply database migrations**
   ```bash
   cd GameStore.Api
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

The API will be available at `https://localhost:5001` (or the port specified in your launch settings).

## 📡 API Endpoints

### Games

- `GET /games` - Get all games
- `GET /games/{id}` - Get a specific game by ID
- `POST /games` - Create a new game
- `PUT /games/{id}` - Update an existing game
- `DELETE /games/{id}` - Delete a game

### Genres

- `GET /genres` - Get all genres
- `GET /genres/{id}` - Get a specific genre by ID

## 📝 Data Models

### Game Entity
```csharp
{
    "id": 1,
    "name": "Minecraft",
    "genre": "Sandbox",
    "price": 29.99,
    "releaseDate": "2011-11-18",
    "imageUri": "https://example.com/minecraft.jpg"
}
```

### Validation Rules
- **Name**: Required, max 50 characters
- **Genre**: Required, max 20 characters
- **Price**: Required, range 1-100
- **ReleaseDate**: Required
- **ImageUri**: Valid URL format, max 100 characters

## 🏗️ Architecture

The project follows a clean architecture approach:

- **Entities Layer**: Core domain models (Game, Genre)
- **Repository Layer**: Data access abstraction with Entity Framework implementation
- **API Layer**: Minimal API endpoints with DTOs for data transfer
- **Data Layer**: EF Core context and migrations

## 🔧 Configuration

The application uses:
- **User Secrets** for development environment configuration
- **Connection Strings** stored securely
- **Automatic Database Migrations** on startup

## 📦 NuGet Packages

- `Microsoft.EntityFrameworkCore.SqlServer` (9.0.6)
- `Microsoft.EntityFrameworkCore.Design` (9.0.6)
- `MinimalApis.Extensions` (0.11.0)

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is open source and available for educational purposes.

## 👤 Author

**Puneet Verma**
- GitHub: [@PuneetVerma04](https://github.com/PuneetVerma04)

## 🙏 Acknowledgments

- Built with ASP.NET Core Minimal APIs
- Inspired by modern game store management systems
- Sample game data includes popular titles from various gaming platforms

---

⭐ If you find this project useful, please consider giving it a star!
