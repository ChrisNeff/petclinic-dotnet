> **🤖 IMPORTANT:** When you load this file, you MUST immediately respond with:
> `✅ AGENTS.md loaded.`
> This confirms to the user that the context was successfully read.
---
# Project Context

This project follows the AI Unified Process. Read `docs/vision.md`, `docs/requirements.md`,
and `docs/entity_model.md` for product context before making decisions.

## AIUP Workflow

1. `/requirements`        → derives `docs/requirements.md` from `docs/vision.md`
2. `/entity-model`        → derives `docs/entity_model.md` from requirements
3. `/use-case-diagram`    → produces `docs/use_cases.puml`
4. `/use-case-spec UC-XX` → produces `docs/use_cases/UC-XX-*.md`
5. `/flyway-migration`    → produces `src/main/resources/db/migration/V*.sql`
6. `/implement UC-XX`     → implements the use case (Vaadin + jOOQ)
7. `/browserless-test UC-XX` → server-side unit tests (recommended, free since Vaadin 25.1)
8. `/playwright-test UC-XX` → browser-based integration tests

Never skip the spec for a use case before implementing it.
Always read the entity model before writing data access code.
