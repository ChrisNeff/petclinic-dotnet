# UC-003: View Owner Profile

## Overview

| Field         | Value                                                          |
|---------------|----------------------------------------------------------------|
| ID            | UC-003                                                         |
| Name          | View Owner Profile                                             |
| Primary Actor | Receptionist                                                   |
| Goal          | Review a client's contact information, their pets, and each pet's complete visit history |
| Status        | Implemented                                                    |

## Preconditions

1. The owner record exists in the system.

## Main Success Scenario

1. Receptionist navigates to an owner's profile (via owner search results or a direct link).
2. System loads the owner record together with all associated pets, each pet's type, and each pet's full visit history.
3. System displays the owner's name, address, city, and telephone number.
4. System displays a list of the owner's pets; for each pet: name, type, date of birth, and a chronological list of clinic visits with date and description.

## Alternative Flows

### A1: Owner not found

At step 2, no owner record exists for the requested ID.

System returns a 404 Not Found response. The profile page is not displayed.

## Postconditions

- **Success:** Owner profile is displayed with all pets and visits.
- **Failure:** Not Found page is shown; no data is changed.

## Business Rules

- **BR-003:** The owner profile displays pets with their visit history loaded in a single query — no lazy-load round trips are required after the page is rendered.
