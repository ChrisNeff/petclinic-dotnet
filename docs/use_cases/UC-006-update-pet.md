# UC-006: Update Pet Information

## Overview

| Field         | Value                                                   |
|---------------|---------------------------------------------------------|
| ID            | UC-006                                                  |
| Name          | Update Pet Information                                  |
| Primary Actor | Receptionist                                            |
| Goal          | Correct a pet's name, date of birth, or type            |
| Status        | Implemented                                             |

## Preconditions

1. The pet record exists in the system.
2. At least one pet type is defined in the reference data.

## Main Success Scenario

1. Receptionist opens the Edit Pet form (typically via a link on the owner's profile page).
2. System loads the pet's current data and pre-fills all form fields; the pet type dropdown is populated from the reference list sorted alphabetically.
3. Receptionist edits one or more fields and submits the form.
4. System validates the input.
5. System saves the updated pet record and redirects to the associated owner's profile page (UC-003).

## Alternative Flows

### A1: Required fields are cleared or invalid

At step 4, one or more required fields are blank after editing.

System redisplays the edit form with validation error messages and re-populates the pet type list. No changes are saved. Receptionist corrects the errors and resubmits.

### A2: Pet not found

At step 2, the pet record does not exist.

System returns a 404 Not Found response. The edit form is not displayed.

## Postconditions

- **Success:** Updated pet record is saved; owner profile page is displayed reflecting the changes.
- **Validation failure:** No changes are saved; edit form is redisplayed with error messages.
- **Not found:** No changes are saved; Not Found page is shown.

## Business Rules

- **BR-005:** Pet name, date of birth, and pet type are required. *(see UC-005)*
- **BR-006:** Pet type must be selected from the predefined reference list. *(see UC-005)*
