# UC-005: Add a Pet to an Owner

## Overview

| Field         | Value                                                       |
|---------------|-------------------------------------------------------------|
| ID            | UC-005                                                      |
| Name          | Add a Pet to an Owner                                       |
| Primary Actor | Receptionist                                                |
| Goal          | Register a new pet under a specific client's account        |
| Status        | Implemented                                                 |

## Preconditions

1. The owner record exists in the system.
2. At least one pet type is defined in the reference data.

## Main Success Scenario

1. Receptionist opens the Add Pet form from the owner's profile page.
2. System pre-associates the new pet with the owner and presents a blank form with fields for name, date of birth, and pet type (populated from the reference list, sorted alphabetically).
3. Receptionist fills in all fields, selects a pet type, and submits the form.
4. System validates the input.
5. System creates the pet record linked to the owner and redirects to the owner's profile page (UC-003).

## Alternative Flows

### A1: Required fields are missing or invalid

At step 4, name, date of birth, or pet type is missing.

System redisplays the Add Pet form with validation error messages and re-populates the pet type list. Pet record is not created. Receptionist corrects the errors and resubmits.

### A2: Owner not found

At step 1, the owner record does not exist.

System returns a 404 Not Found response. The form is not displayed.

## Postconditions

- **Success:** New pet record is saved and linked to the owner; owner profile is displayed showing the new pet.
- **Failure:** No record is created; form is redisplayed with error messages.

## Business Rules

- **BR-004:** A pet must be associated with exactly one owner at creation time; the owner cannot be changed after creation.
- **BR-005:** Pet name, date of birth, and pet type are all required.
- **BR-006:** Pet type must be selected from the predefined reference list.
