# 🚀 .NET & C# Concepts Playground

Welcome to my ultimate playground for exploring, implementing, and mastering the full spectrum of **.NET** and **C#**. This repository serves as a living laboratory where I experiment with everything from foundational language features to advanced architectural patterns in modern backend development.

The core goal of this project is to build a robust, scalable **ASP.NET Core Web API** while systematically implementing advanced language concepts and architectural best practices.

---

## 🛠️ Tech Stack & Prerequisites

- **Language:** C# 12 / C# 13
- **Framework:** .NET 8 / .NET 9 SDK
- **Database:** Entity Framework Core (SQL Server / PostgreSQL / In-Memory)
- **Tools:** .NET CLI, Visual Studio / VS Code, Git

---

## 🏗️ Architecture & Patterns

This project is built following **Clean Architecture** or **Hexagonal Architecture** principles to ensure loose coupling, high testability, and clear separation of concerns.

### Core Concepts Implemented:
- **Dependency Injection (DI):** Leveraging native IoC containers using `Transient`, `Scoped`, and `Singleton` lifetimes.
- **Repository & Unit of Work Patterns:** Abstracting data access and ensuring atomic business transactions.
- **CQRS (Command Query Responsibility Segregation):** Separating read and write operations (using MediatR).
- **Options Pattern:** Strongly-typed configuration management linked with `appsettings.json`.

---

## 🔬 C# Language Features Index

Here is a map of the advanced C# language features implemented throughout the codebase:

### 1. Modern Syntax & Performance
- **Records (`record`, `record struct`):** Used for lightweight, immutable Data Transfer Objects (DTOs).
- **Pattern Matching:** Advanced switch expressions, relational patterns, and property patterns for clean conditional logic.
- **Pattern Matching & Tuples:** Utilized in domain services for complex state checks.
- **Primary Constructors:** Applied to classes and records to reduce boilerplate code during dependency injection.

### 2. Memory & Type Safety
- **Nullable Reference Types (NRT):** Enforced globally to eliminate `NullReferenceException` risks.
- **Generics & Constraints:** Reusable repository interfaces and generic API response wrappers.
- **Asynchronous Programming:** Ubiquitous use of `async`/`await`, `Task`, and `ValueTask` to maximize I/O performance.

---

## 📡 ASP.NET Core Web API Architecture

The API layer acts as the orchestrator of the ecosystem, showcasing modern RESTful web design.

- **Minimal APIs vs. Controllers:** Features both traditional Controller-based endpoints and high-performance Minimal APIs.
- **Global Error Handling:** Implemented using a custom middleware or `IExceptionHandler` to intercept exceptions and return structured `ProblemDetails` responses.
- **Data Validation:** FluentValidation integrated directly into the request pipeline.
- **Logging & Observability:** Structured logging configured via Serilog with file and console sinks.
- **Background Tasks:** Hosted Services (`IHostedService` / `BackgroundService`) managing asynchronous queue processing or scheduled cron jobs.

---

## 💾 Data Access (Entity Framework Core)

The persistence layer demonstrates deep familiarity with database interactions.

- **Code-First Approach:** Fluent API configurations for entity relationships (1:1, 1:N, N:M).
- **Performance Optimizations:** - `AsNoTracking()` for read-only queries.
  - Compiled Queries and Eager/Explicit/Lazy loading strategies.
- **Database Migrations:** Programmatic migration execution at application startup.

---

## 🚦 Getting Started

### 1. Clone the repository
```bash
git clone [https://github.com/Hayk555-hayk/dotnetProject.git]
cd dotnetProject
