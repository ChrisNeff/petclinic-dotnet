# UC-008: View Veterinarian Directory

## Overview

| Field         | Value                                                        |
|---------------|--------------------------------------------------------------|
| ID            | UC-008                                                       |
| Name          | View Veterinarian Directory                                  |
| Primary Actor | Veterinarian, Receptionist                                   |
| Goal          | Browse the full list of clinic vets and their specialties    |
| Status        | Implemented                                                  |

## Preconditions

1. The application is accessible on the clinic network.

## Main Success Scenario

1. User opens the Veterinarians page.
2. System loads all vets together with their assigned specialties.
3. System displays the list of vets sorted alphabetically by last name; for each vet, the page shows their full name and any specialties they hold. Vets with no specialties are shown with an empty specialties list.

## Alternative Flows

*None — the directory is a read-only view with no user input; the only expected variation (empty vet table) is an operational state, not a business error.*

## Postconditions

- **Success:** Veterinarian directory is displayed with up-to-date specialty assignments.

## Business Rules

- **BR-010:** Vets are displayed sorted alphabetically by last name.
- **BR-011:** A vet may have zero or more specialties; a specialty may be shared by multiple vets.
