# UC-004: Update Owner Information

## Overview

| Field         | Value                                                     |
|---------------|-----------------------------------------------------------|
| ID            | UC-004                                                    |
| Name          | Update Owner Information                                  |
| Primary Actor | Receptionist                                              |
| Goal          | Correct or update a client's contact details              |
| Status        | Implemented                                               |

## Preconditions

1. The owner record exists in the system.

## Main Success Scenario

1. Receptionist opens the Edit Owner form for a specific owner (typically via a link on the owner profile).
2. System loads the current owner data and pre-fills all form fields.
3. Receptionist edits one or more fields and submits the form.
4. System validates the input.
5. System saves the updated record and redirects to the owner's profile page (UC-003).

## Alternative Flows

### A1: Required fields are cleared or invalid

At step 4, one or more required fields are blank after editing.

System redisplays the edit form with validation error messages. No changes are saved. Receptionist corrects the errors and resubmits.

### A2: Owner not found

At step 2, the owner record no longer exists (deleted via another session or direct API call).

System returns a 404 Not Found response. The edit form is not displayed.

## Postconditions

- **Success:** Updated owner record is saved; owner profile page is displayed with the new information.
- **Validation failure:** No changes are saved; edit form is redisplayed with error messages.
- **Not found:** No changes are saved; Not Found page is shown.

## Business Rules

- **BR-002:** All owner fields (first name, last name, address, city, telephone) are required. *(see UC-002)*
