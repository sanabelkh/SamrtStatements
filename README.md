# SmartStatements

SmartStatements is a sample **Finance House – Monthly Statements System** built as a technical interview task.
The project focuses on **Clean Architecture**, **CQRS**, **MediatR**, and **FluentValidation**, using **In-Memory storage** and email delivery.

This README is written based strictly on the actual solution structure .

---

## Architecture Overview

The solution follows **Clean Architecture** principles.

### Core Layer

- Contains **Domain entities** such as `Customer` and `Statement`
- Defines **interfaces** for repositories and services
- Contains **CQRS contracts** (Commands, Queries)
- Has no dependency on Infrastructure or API

### Application Logic (inside Core)

- CQRS is implemented inside the `Statements` folder
- Handlers contain business logic
- Validators enforce input rules using FluentValidation

### Infrastructure Layer

- Implements repository interfaces
- Uses **InMemoryDb** as a fake persistence layer
- Contains email services (SMTP or Fake implementation)

### API Layer

- Exposes HTTP endpoints
- Uses MediatR to send Commands and Queries
- Contains no business logic

---

## CQRS Design

### Commands

Used for write operations:

- Generate monthly statements
- Generate a single statement

### Queries

Used for read operations:

- Get customer statement by month , CustomerID , Year

### Handlers

- Each command or query has a single handler
- Business logic lives only in handlers

---

## Validation

- FluentValidation is used for validating commands
- Validators live in the `Validators` folder
- Validation runs automatically through a MediatR pipeline behavior

---

## Email Delivery

Email sending is triggered after generating statements.

Available implementations:

- FakeEmailService (for local testing)
- SmtpEmailService (real SMTP configuration)

Email content is simple text (no PDF generation).

---

## Data Storage

- No database is used
- All data is stored in memory using `InMemoryDb`
- Customers and Statements are stored as lists

---

## API Usage

Example endpoint:

```
POST /api/statements/generate-monthly
```

Behavior:

- Generates monthly statements for all customers in memory
- Sends statement emails automatically
- Fetch Customer Statement By Custmer ID , Year , Month

---

## Purpose

This project was built to demonstrate:

- Clean Architecture
- CQRS with MediatR
- FluentValidation
- Dependency Injection
- Separation of concerns

It is intentionally simple and suitable for interview and assessment scenarios.

---

## Notes

- No authentication or authorization
- No external database
- Easy to extend with real persistence and transactions

---

## Author

And Created By == Sanabel AL-khatib == Date And Time : 1/18/2026 21:02 PM Jordan Time.
Developed as a technical interview task for a finance house system.
