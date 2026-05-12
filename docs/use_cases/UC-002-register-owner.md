# UC-002: Register a New Owner

## Overview

| Field         | Value                                              |
|---------------|----------------------------------------------------|
| ID            | UC-002                                             |
| Name          | Register a New Owner                               |
| Primary Actor | Receptionist                                       |
| Goal          | Create a new client record so their pets can be tracked |
| Status        | Implemented                                        |

## Preconditions

1. The application is accessible on the clinic network.

## Main Success Scenario

1. Receptionist navigates to the New Owner form.
2. System presents a blank form with fields for first name, last name, address, city, and telephone.
3. Receptionist fills in all fields and submits the form.
4. System validates the input.
5. System creates the owner record and redirects to the new owner's profile page (UC-003).

## Alternative Flows

### A1: Required fields are missing or invalid

At step 4, one or more required fields are blank.

System redisplays the form with validation error messages. Owner record is not created. Receptionist corrects the errors and resubmits.

## Postconditions

- **Success:** New owner record is saved; owner profile page is displayed.
- **Failure:** No record is created; form is redisplayed with error messages.

## Business Rules

- **BR-002:** All owner fields (first name, last name, address, city, telephone) are required.
