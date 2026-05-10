# PetClinic

A .NET port of the [Spring PetClinic](https://github.com/spring-projects/spring-petclinic) sample application. Demonstrates clean architecture patterns in a familiar domain — useful as a starting point for talks, workshops, and client demos.

## Setup

**Prerequisites:** .NET SDK, `dotnet-ef` tool

```bash
dotnet tool install -g dotnet-ef   # skip if already installed
```

**Run:**

```bash
git clone https://github.com/ChrisNeff/petclinic-dotnet
cd petclinic-dotnet
dotnet run --project PetClinic.Web
```

The database is created and seeded with the Spring PetClinic sample data automatically on first run.

- UI: `http://localhost:<port>`
- Swagger: `http://localhost:<port>/swagger`

## Project Structure

```
PetClinic.sln
├── PetClinic.Core/              # No external dependencies
│   ├── Entities/                # Owner, Pet, PetType, Vet, Specialty, VetSpecialty, Visit
│   └── Interfaces/              # IRepository<T>, IOwnerRepository, IVetRepository
├── PetClinic.Infrastructure/    # Data access — depends on Core
│   ├── Data/                    # DbContext, Fluent config, Migrations, Seed data
│   └── Repositories/            # Concrete implementations
└── PetClinic.Web/               # Web layer — depends on Core + Infrastructure
    ├── Pages/                   # Razor Pages: Owners, Pets, Visits, Vets
    └── Controllers/             # REST API: /api/owners, /api/pets, /api/vets, /api/pets/{id}/visits
```

## API Endpoints

| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/owners` | List all owners (optional `?lastName=` filter) |
| GET | `/api/owners/{id}` | Owner with pets and visit history |
| POST | `/api/owners` | Create owner |
| PUT | `/api/owners/{id}` | Update owner |
| DELETE | `/api/owners/{id}` | Delete owner |
| GET | `/api/pets/{id}` | Get pet |
| POST | `/api/owners/{ownerId}/pets` | Add pet to owner |
| PUT | `/api/pets/{id}` | Update pet |
| DELETE | `/api/pets/{id}` | Delete pet |
| GET | `/api/vets` | All vets with specialties |
| GET | `/api/pets/{petId}/visits` | Visit history for a pet |
| POST | `/api/pets/{petId}/visits` | Add visit |

## Database

SQLite by default (zero config). To switch to SQL Server, update the connection string in `appsettings.json` and swap the SQLite package for `Microsoft.EntityFrameworkCore.SqlServer`.

## Pre-Demo Checklist

- [ ] `dotnet build` — clean build, zero warnings
- [ ] `dotnet run --project PetClinic.Web` — app starts, seed data visible
- [ ] `/swagger` — endpoints listed and responding

---

Reference: [Spring PetClinic](https://github.com/spring-projects/spring-petclinic)
