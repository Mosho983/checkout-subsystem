# Checkout Subsystem – Superstars Shoes Web App

This repository contains my contribution to a team-based Software Engineering project at De Montfort University.

## Project Overview

The full project was an e-commerce-style web application for a fictional shoe store, developed collaboratively by a student team using Agile/Scrum practices.

This module handles checkout and order processing, built using:
- ASP.NET Web Forms
- SQL Server (T-SQL + Stored Procedures)
- Bootstrap 5
- MSTest (Unit Testing)

## My Responsibilities

I was responsible for designing and implementing the Checkout subsystem, which includes:

- CRUD operations for orders and checkouts
- Filtering by order status using stored procedures
- Displaying data in GridView controls
- Backend logic (C#) and SQL interaction via ADO.NET
- Unit testing for business logic and collections
- Layered architecture separating UI, logic, and data access

## Key Features

- Add/Edit/Delete checkout records
- Filter checkouts by status or date
- MSTest unit tests for data and logic verification
- Bootstrap-styled UI for a clean admin interface

## Structure

/App_Code/
- clsCheckouts.cs
- clsCheckoutCollection.cs
- tstCheckout.cs
- tstCheckoutCollection.cs

/CheckoutAdmin/
- Default.aspx
- Default.aspx.cs

## Naming Note

File naming conventions (e.g., `clsCheckouts`) were inherited from the team project skeleton provided by the university. They remain unchanged to reflect the original structure.

## Disclaimer

This repository includes only my code. Shared components, database schemas, and work done by other teammates have been excluded in compliance with academic integrity policies.
