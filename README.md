Here's a README.md file for your ITSM project that includes setup instructions and sample user information:

```markdown
# ITSM Project

A Blazor-based IT Service Management system with user management, team management, and ticket tracking capabilities.

## Getting Started

### Prerequisites
- .NET 9.0 SDK or later
- SQLite

### Installation Steps

1. Clone the repository
```bash
git clone [your-repository-url]
cd ITSMProject
```

2. Update the database
```bash
dotnet ef database update
```

3. Run the application
```bash
dotnet watch run
```

The application will start at `https://localhost:xxxx`

## Default Users

The following sample users are created automatically for testing:

### Admin User
- Username: `admin@admin.com`
- Password: `Admin!123`
- Role: Administrator

### Technician Agent
- Username: `tech@admin.com`
- Password: `Test!123`
- Role: Support Technician

### Regular User
- Username: `test@user.com`
- Password: `Test!123`
- Role: User

## User Roles and Permissions

- **Administrator**: Full system access, can manage users, teams, and all tickets
- **Team Lead**: Can manage team members and their assigned tickets
- **Support Agent**: Can work on assigned tickets and update their status
- **User**: Can create and view their own tickets

## Features

- User Management
- Team Management
- Ticket Management with categories and priorities
- Role-based access control
- Real-time ticket updates
- Team assignment and collaboration

## Development Notes

### Database Migration
To create a new migration:
```bash
dotnet ef migrations add [MigrationName]
dotnet ef database update
```

### Running Tests
```bash
dotnet test
```

## Technology Stack

- ASP.NET Core 9.0
- Blazor Server
- Entity Framework Core
- SQLite Database
- MudBlazor UI Components
- ASP.NET Core Identity

## Support

For issues and feature requests, please create an issue in the repository.
```
