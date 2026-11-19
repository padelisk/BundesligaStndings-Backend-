# BundesligaStndings(Backend)


A REST API built with **ASP.NET Core (.NET 10)** that shows the live Bundesliga table
and lets users register and log in with a favourite team.

## Features
- Live Bundesliga standings from the public [OpenLigaDB](https://www.openligadb.de/) API
- Position and zone for each team (Champions League, Europa League, Conference League, play-off, relegation)
- User registration and login with **hashed passwords**
- Input validation with DataAnnotations
- Interactive documentation with **Swagger**

## Architecture
Layered architecture with interfaces and Dependency Injection:

```
Controllers  →  Services  →  Data  →  MySQL / OpenLigaDB
```

| Folder | Responsibility |
|---|---|
| `Controllers` | HTTP endpoints, status codes |
| `Services` | Business logic (password hashing, positions, zones) |
| `Data/Repositories` | MySQL access with parameterised SQL |
| `Data/ExternalApi` | HTTP client for OpenLigaDB |
| `Models` | Domain objects (`User`, `Team`) |
| `Dto` | Request / response objects |


## Tech stack
C# · ASP.NET Core Web API · MySQL · MySqlConnector · HttpClient · Swagger / OpenAPI

## How to run
1. Run `database.sql` in MySQL Workbench.
2. In Visual Studio: right-click the project → **Manage User Secrets** and add:
   ```json
   {
     "ConnectionStrings": {
       "Default": "Server=localhost;Port=3306;Database=bundesliga;User=root;Password=YOUR_PASSWORD"
     }
   }
   ```
3.  Swagger opens at `/swagger`.
