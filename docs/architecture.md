# Architecture: PetClinic (.NET)

## Solution Structure

```
PetClinic.sln
├── PetClinic.Core/           # Domain layer — entities and repository interfaces
├── PetClinic.Infrastructure/ # Data layer — EF Core DbContext and repository implementations
└── PetClinic.Web/            # Presentation layer — Razor Pages UI and REST API controllers
```

**Dependency rule:** Core ← Infrastructure ← Web. Core has no external dependencies.

## Tech Stack

| Concern | Technology |
|---------|------------|
| Runtime | .NET 8 |
| Web framework | ASP.NET Core 8 |
| UI | Razor Pages |
| REST API | ASP.NET Core controllers (`[ApiController]`) |
| ORM | Entity Framework Core 8 |
| Database | SQLite (`PetClinic.Web/petclinic.db`) |
| API docs | Swashbuckle / Swagger UI |
| Schema management | EF Core Migrations |

## Data Access Pattern

`IRepository<T>` provides generic CRUD for all entities. Specialized repositories extend it for domain-specific queries:

- `IOwnerRepository` — adds `SearchByLastNameAsync`, `GetByIdWithPetsAsync`
- `IVetRepository` — adds vet-specific queries with specialty includes

All entities inherit `BaseEntity` (provides `Id: int`).

**Adding a new repository method:**
1. Add the method signature to the interface in `PetClinic.Core/Interfaces/`
2. Implement it in `PetClinic.Infrastructure/Repositories/`
3. Register a new specialized repository in `Program.cs` if needed

## API Conventions

- All controllers: `[ApiController]`, `[Produces("application/json")]`
- Flat routes: `api/{resource}` (e.g., `api/owners`)
- Nested routes: `api/{parent}/{parentId}/{child}` (e.g., `api/pets/{petId}/visits`)
- Return `IActionResult` — use `Ok()`, `NotFound()`, `CreatedAtAction()`, `ValidationProblem()`, `NoContent()`
- Validation via `ModelState.IsValid` — no manual validation logic
- No API versioning in scope

## Razor Pages UI

- Pages live in `PetClinic.Web/Pages/{Resource}/`
- Standard CRUD pages per resource: `Index`, `Detail`, `Create`, `Edit`
- Page models inject repository interfaces directly — no separate service layer

## EF Core Migrations

Schema changes are managed via EF Core Migrations, not raw SQL.

```bash
# After changing an entity, add a migration
dotnet ef migrations add <MigrationName> \
  --project PetClinic.Infrastructure \
  --startup-project PetClinic.Web

# Apply pending migrations manually
dotnet ef database update \
  --project PetClinic.Infrastructure \
  --startup-project PetClinic.Web
```

Migrations apply automatically on startup via `db.Database.Migrate()` in `Program.cs`.

Seed data is defined in `AppDbContext.OnModelCreating` using `modelBuilder.Entity<T>().HasData(...)`.

## Configuration

- Connection string: `appsettings.json` → `ConnectionStrings:DefaultConnection`
- Development overrides: `appsettings.Development.json`

## Testing

No test project exists yet. When added, use xUnit with the project named `PetClinic.Tests`.

## Out of Scope

Authentication, appointment scheduling, billing, prescriptions, multi-clinic support, and analytics are explicitly excluded.

→ See `docs/vision.md` for the full scope definition.
