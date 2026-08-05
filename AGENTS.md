> **🤖 IMPORTANT:** When you load this file, you MUST immediately respond with:
> `✅ AGENTS.md loaded.`
> This confirms to the user that the context was successfully read.
---
# Project Context

This project follows the AI Unified Process on a .NET stack. Before making any decisions, read:
- `docs/vision.md` — product scope and constraints
- `docs/requirements.md` — functional and non-functional requirements
- `docs/entity_model.md` — domain entity model
- `docs/architecture.md` — tech stack, solution structure, and coding conventions

## AIUP Workflow

1. `/requirements`        → derives `docs/requirements.md` from `docs/vision.md`
2. `/entity-model`        → derives `docs/entity_model.md` from requirements
3. `/use-case-diagram`    → produces `docs/use_cases.puml`
4. `/use-case-spec UC-XX` → produces `docs/use_cases/UC-XX-*.md`
5. EF Core migration      → `dotnet ef migrations add <Name> --project PetClinic.Infrastructure --startup-project PetClinic.Web`
6. `/implement UC-XX`     → implements the use case (ASP.NET Core controller + Razor Page + EF Core repository)
7. `/playwright-test UC-XX` → browser-based integration tests

Never skip the spec for a use case before implementing it.
Always read `docs/entity_model.md` and `docs/architecture.md` before writing data access code.

## Implementation Notes

- New entities go in `PetClinic.Core/Entities/`, must inherit `BaseEntity`
- New repository interfaces go in `PetClinic.Core/Interfaces/`
- Repository implementations go in `PetClinic.Infrastructure/Repositories/`
- Register new repositories in `PetClinic.Web/Program.cs`
- Schema changes require an EF Core migration — never edit the SQLite file directly
- Follow existing API conventions: `[ApiController]`, `IActionResult`, route patterns in `docs/architecture.md`

## Agent skills

### Issue tracker

Issues live in GitHub Issues (ChrisNeff/petclinic-dotnet), via the `gh` CLI. See `docs/agents/issue-tracker.md`.

### Triage labels

Default vocabulary: needs-triage, needs-info, ready-for-agent, ready-for-human, wontfix. See `docs/agents/triage-labels.md`.

### Domain docs

Single-context — one `CONTEXT.md` + `docs/adr/` at the repo root. See `docs/agents/domain.md`.
