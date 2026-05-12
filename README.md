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

## Adding a Feature (AIUP Workflow)

This project follows the [AI Unified Process](https://unifiedprocess.ai). New features move through a spec-first pipeline — the specification is the source of truth, not the code.

### Key Documents

| File | Purpose |
|------|---------|
| `docs/vision.md` | Product scope and constraints |
| `docs/requirements.md` | Functional requirements (FR-XXX) |
| `docs/entity_model.md` | Domain entity model |
| `docs/architecture.md` | Tech stack and coding conventions |
| `docs/use_cases/UC-XXX-*.md` | Use case specifications |

### Steps

**1. Update the requirement**

Add a new row to `docs/requirements.md` with a stable ID (`FR-010`, etc.) and a user story:
> *As a [role], I want [goal] so that [benefit].*

If the feature changes product scope, update `docs/vision.md` first and re-run `/requirements`.

**2. Update the entity model** (if needed)

If the feature requires new entities or fields, update `docs/entity_model.md` (or run `/entity-model` to regenerate). Minor features typically require no entity changes.

**3. Write the use case spec**

```
/use-case-spec FR-XXX
```

Generates `docs/use_cases/UC-XXX-*.md` with preconditions, main success scenario, alternative flows, and postconditions. **Never skip this step before implementing.**

**4. Add an EF Core migration** (if schema changed)

```bash
dotnet ef migrations add <MigrationName> \
  --project PetClinic.Infrastructure \
  --startup-project PetClinic.Web
```

**5. Implement the use case**

```
/implement UC-XXX
```

Generates the ASP.NET Core controller, Razor Page, and EF Core repository method from the use case spec and entity model. Always read `docs/architecture.md` before writing data access code manually.

**6. Generate tests**

```
/playwright-test UC-XXX
```

**7. Close the loop**

- Bug in behavior → update the use case spec first, then regenerate code
- Structural refactor → update code, then sync the spec to match

---

## Pre-Demo Checklist

- [ ] `dotnet build` — clean build, zero warnings
- [ ] `dotnet run --project PetClinic.Web` — app starts, seed data visible
- [ ] `/swagger` — endpoints listed and responding

---

Reference: [Spring PetClinic](https://github.com/spring-projects/spring-petclinic)
