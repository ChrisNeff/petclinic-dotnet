# UC-007: Log a Visit

## Overview

| Field         | Value                                                         |
|---------------|---------------------------------------------------------------|
| ID            | UC-007                                                        |
| Name          | Log a Visit                                                   |
| Primary Actor | Receptionist                                                  |
| Goal          | Record a clinic appointment for a pet with the date and clinical notes |
| Status        | Implemented                                                   |

## Preconditions

1. The pet record exists in the system.

## Main Success Scenario

1. Receptionist opens the New Visit form for a specific pet (via a link on the owner's profile page).
2. System loads the pet's name and owner, and pre-fills the visit date with today's date.
3. Receptionist confirms or adjusts the visit date, enters a description of the visit, and submits the form.
4. System validates the input.
5. System creates the visit record linked to the pet and redirects to the owner's profile page (UC-003).

## Alternative Flows

### A1: Required fields are missing or invalid

At step 4, visit date or description is blank.

System redisplays the New Visit form with the pet name still shown and validation error messages. Visit record is not created. Receptionist corrects the errors and resubmits.

### A2: Pet not found

At step 2, the pet record does not exist.

System returns a 404 Not Found response. The form is not displayed.

## Postconditions

- **Success:** Visit record is saved and linked to the pet; owner profile is displayed with the new visit appearing in the pet's history.
- **Failure:** No record is created; form is redisplayed with error messages.

## Business Rules

- **BR-007:** Visit date and description are required.
- **BR-008:** Visit date defaults to today's date when the form is first opened, but the receptionist may change it.
- **BR-009:** A visit must be linked to exactly one pet; the pet association cannot be changed after creation.
