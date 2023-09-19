<div align="center">
  <h1>📧 Email Management System 📧</h1>
  <p><i>A .NET 6 application for managing EmailHtmlTemplate, EmailReceivers, and Users with JWT authentication, Entity Framework, repository pattern, AutoMapper, FluentValidation, Hangfire, and more.</i></p>
</div>

---

## ⚙️ Prerequisites

Before running this project, ensure you have the following prerequisites installed:

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- Visual Studio or your preferred IDE
- SQL Server
- Docker
- Postgresql
- Create a database named `EmailManagementDb`

## 🚀 Getting Started

After creating the database, update the `ConnectionStrings` in `appsettings.json` with your database connection string.

### Create Hangfire Db

Run this command in terminal with Docker running

```
docker run --name postgres-hangfire -e POSTGRES_PASSWORD=mysecretpassword -e POSTGRES_DB=HangfireDb -p 5200:5432 -d postgres:latest
```

### Create Email Db

Run this command in terminal with Docker running

```
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=YourStrongPassword123' -e 'MSSQL_PID=Express' -p 1433:1433 --name sql-server-emaildb -d mcr.microsoft.com/mssql/server:latest
```

After running this commands, change the connectionStrings in appsettings.json.

### Run Migrations

To apply database schema changes, run the following commands:

```bash
dotnet ef database update
```

### Configure JWT Authentication

Update the JWT settings in `appsettings.json`:

```json
{
 "Jwt": {
   "Audience": "https://localhost:7000",
   "Issuer": "https://localhost:7000",
   "Sec": "security"
 }
}
```

### Start the Application

Build and run the application:

```bash
dotnet run
```

## 🛠️ Technologies Used

- .NET 6
- Entity Framework Core
- AutoMapper
- FluentValidation
- JWT Authentication
- Hangfire
- SQL Server
- Postgresql

---
