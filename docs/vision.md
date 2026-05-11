# Vision: PetClinic (.NET)

## Mission

PetClinic helps small veterinary clinics manage their day-to-day operations — tracking pet owners,
their animals, and visit history in one place. Staff spend less time hunting through paper records
and more time with patients. The application is also a reference codebase for .NET developers,
offering a clean, well-understood domain to learn and demonstrate modern software patterns.

## Target Users

- **Clinic receptionists** — the primary daily users; they register new clients, maintain owner
  and pet records, and log visits after each appointment.
- **Veterinarians** — consult the app to review a pet's visit history before and after
  appointments, and appear in a published staff directory with their specialties.
- **Developers and presentation attendees** — use the running application and source code as a
  learning reference when studying software architecture and .NET best practices.

## Goals

- Eliminate manual, paper-based record keeping for owner, pet, and visit data at a small clinic.
- Give receptionists a fast, searchable directory so they can pull up any owner or pet in seconds.
- Provide vets with immediate access to a pet's complete visit history before an appointment.
- Serve as the go-to reference application for .NET architecture talks and workshops — familiar
  enough to focus attention on the patterns, not the domain.

## Scope

- **In scope:**
  - Owner profiles (contact details, linked pets)
  - Pet records (name, breed/type, date of birth, owning client)
  - Visit log per pet (date, reason, attending vet notes)
  - Vet staff directory with listed specialties
  - Search for owners by last name
  - A public-facing web interface for clinic staff
  - A REST API for potential integrations or workshop exercises

- **Out of scope:**
  - Appointment scheduling or calendar management
  - Billing, invoicing, or payment processing
  - Prescription or medication tracking
  - Multi-location or multi-clinic support
  - Patient portal or client-facing access
  - Email or SMS notifications
  - Reporting and analytics

## Constraints

- The application must be operable by non-technical clinic staff with no training beyond a
  brief walkthrough.
- It must remain recognizable as the classic PetClinic domain so it can serve its educational
  purpose alongside the original Spring reference application.
- It must run on standard clinic hardware (a modern web browser is the only client requirement).
- No user authentication is in scope for this version; the app assumes a trusted internal network.
