web     := "PetClinic.Web/PetClinic.Web.csproj"
infra   := "PetClinic.Infrastructure/PetClinic.Infrastructure.csproj"

# List available recipes
default:
    @just --list

# Build the solution
build:
    dotnet build

# Kill any running instance (macOS/Linux)
kill-mac:
    -pkill -f "dotnet.*PetClinic" 2>/dev/null
    -lsof -ti :5139 | xargs kill -9 2>/dev/null

# Kill any running instance (Windows — run in PowerShell)
kill-win:
    -taskkill /F /FI "IMAGENAME eq dotnet.exe" 2>NUL
    -for /f "tokens=5" %a in ('netstat -aon ^| findstr ":5139 "') do taskkill /F /PID %a 2>NUL

# Run the web app (kills any existing instance first)
run: kill-mac
    dotnet run --project {{web}}

# Run with hot reload
watch:
    dotnet watch --project {{web}}

# Clean build artifacts
clean:
    dotnet clean

# Add a new migration (usage: just migrate "MigrationName")
migrate name:
    dotnet ef migrations add {{name}} --project {{infra}} --startup-project {{web}}

# List applied migrations
migrations:
    dotnet ef migrations list --project {{infra}} --startup-project {{web}}

# Drop and recreate the database (destroys all data)
db-reset:
    dotnet ef database drop --force --project {{infra}} --startup-project {{web}}
    dotnet ef database update --project {{infra}} --startup-project {{web}}

# Remove the last migration
migrate-undo:
    dotnet ef migrations remove --project {{infra}} --startup-project {{web}}
