# UC-001: Find an Owner

## Overview

| Field         | Value                                                         |
|---------------|---------------------------------------------------------------|
| ID            | UC-001                                                        |
| Name          | Find an Owner                                                 |
| Primary Actor | Receptionist                                                  |
| Goal          | Locate one or more owner records to navigate to their profile |
| Status        | Implemented                                                   |

## Preconditions

1. The application is accessible on the clinic network.

## Main Success Scenario

1. Receptionist opens the Owners list page.
2. System displays all registered owners sorted alphabetically by last name, showing each owner's name, city, and telephone number.
3. Receptionist types a last name or partial last name into the search field and submits.
4. System filters and displays only owners whose last name contains the search term.
5. Receptionist selects an owner from the results.
6. System displays the selected owner's profile (UC-003).

## Alternative Flows

### A1: Search field is empty

At step 3, receptionist submits without entering a search term.

System displays all owners (same result as step 2).

### A2: No owners match the search term

At step 4, no owner's last name contains the entered text.

System displays an empty results list. Receptionist may clear the search field and try again.

## Postconditions

- **Success:** Owner profile page is displayed.
- **No match:** Owners list remains on screen with an empty result; no data is changed.

## Business Rules

- **BR-001:** Last name search uses substring matching — all owners whose last name contains the search term are returned, regardless of position (prefix, infix, or suffix).
