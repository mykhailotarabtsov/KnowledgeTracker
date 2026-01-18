# 🗺 Knowledge & Project Tracker — Project Roadmap

This document is the **single source of truth** for what this project is, why it exists, and how it should evolve step by step.

---

## 🎯 Project Goal

Build a **real-world backend API** using **ASP.NET Core + MongoDB**, designed to be consumed by a **Vue 3 frontend**, with a strong focus on:

* Backend fundamentals
* NoSQL data modeling
* Clean API design
* Validation & error handling
* Frontend ↔ backend collaboration

This is a **learning-first, production-style pet project**.

---

## 🧠 Product Concept

A **personal knowledge & project tracking system** where a user can:

* Create projects (e.g. *"Learn ASP.NET"*)
* Add tasks to projects
* Track progress
* Store descriptions and notes
* Later: filter, search, tag

Conceptually similar to a **Notion-lite / developer-focused tracker**.

---

## 🏗 High-Level Architecture

```
Vue 3 Frontend
     ↓ REST API
ASP.NET Core Web API
     ↓
MongoDB (Document Database)
```

* Frontend and backend are **fully separated**
* Backend is **API-only**
* MongoDB is the **primary persistence layer**

---

## 🧱 Core Domain Model (Initial Scope)

### Project (Root Aggregate)

```json
{
  "_id": "ObjectId",
  "name": "Learn ASP.NET",
  "description": "Backend fundamentals",
  "createdAt": "UTC datetime",
  "tasks": []
}
```

### Task (Embedded Document)

```json
{
  "id": "GUID",
  "title": "Add CRUD endpoints",
  "isDone": false,
  "createdAt": "UTC datetime"
}
```

**Design choice:**

* Tasks are **embedded** inside projects
* This intentionally teaches document-oriented modeling

---

## 🔌 API Responsibilities

The API is responsible for:

* RESTful endpoints
* Input validation
* Error handling
* Data shaping via DTOs
* Persistence logic

The API is **not** responsible for:

* UI logic
* Rendering
* Complex auth (initially)

---

## 🧩 Planned API Endpoints (Initial)

### Projects

* `GET    /api/projects`
* `GET    /api/projects/{id}`
* `POST   /api/projects`
* `PUT    /api/projects/{id}`
* `DELETE /api/projects/{id}`

### Tasks (Embedded)

* `POST   /api/projects/{id}/tasks`
* `PUT    /api/projects/{id}/tasks/{taskId}`
* `DELETE /api/projects/{id}/tasks/{taskId}`

---

## 🛠 Tech Stack

### Backend

* **ASP.NET Core Web API**
* **.NET 8 (LTS)**
* **MongoDB**
* MongoDB C# Driver
* Swagger / OpenAPI
* Data Annotations for validation

### Frontend (Later)

* **Vue 3**
* Composition API
* Pinia
* Axios
* Tailwind or Vuetify

### Tooling

* VS Code
* REST Client (VS Code extension)
* Git
* MongoDB (local or Atlas)

---

## 🗺 Feature Roadmap (Step-by-Step)

---

## 🟢 Phase 0 — Project Foundation

**Goal:** Clean, stable starting point.

### Tasks

* Create ASP.NET Core Web API project
* Enable Swagger
* Remove demo/template code
* Configure environments
* Add MongoDB connection string
* Install MongoDB driver

### Deliverables

* App runs
* Swagger works
* MongoDB reachable

---

## 🟢 Phase 1 — MongoDB Integration

**Goal:** Establish persistence layer.

### Tasks

* Create `MongoSettings`
* Create `MongoContext`
* Register MongoContext in DI
* Create base Mongo entity (`Id`, `CreatedAt`)
* Verify DB connection

### Deliverables

* Mongo collections accessible
* No controllers yet

---

## 🟢 Phase 2 — Project Entity & CRUD

**Goal:** Persist and manage projects.

### Tasks

* Create `Project` document model
* Create DTOs:

  * `CreateProjectDto`
  * `UpdateProjectDto`
  * `ProjectDto`
* Add validation attributes
* Create `ProjectsController`
* Implement full CRUD

### Deliverables

* Full CRUD via Swagger / REST Client
* `projects` collection populated

---

## 🟢 Phase 3 — Validation & Error Handling

**Goal:** Predictable and robust API behavior.

### Tasks

* Rely on `[ApiController]` validation
* Normalize validation errors
* Add global exception middleware
* Handle:

  * Invalid ObjectId
  * NotFound cases
  * Unexpected exceptions

### Deliverables

* Clean 400 / 404 / 500 responses
* Consistent error shape

---

## 🟢 Phase 4 — Embedded Tasks (NoSQL Modeling)

**Goal:** Learn document-oriented updates.

### Tasks

* Create `TaskItem` embedded model
* Embed tasks in `Project`
* Create task DTOs
* Implement task endpoints
* Use Mongo positional operators

### Deliverables

* Atomic updates
* No separate tasks collection

---

## 🟢 Phase 5 — Querying & Pagination

**Goal:** Real-world querying skills.

### Tasks

* Add pagination to project list
* Add filtering (name, task status)
* Add sorting
* Create MongoDB indexes

### Deliverables

* Efficient queries
* Indexed collections

---

## 🟢 Phase 6 — Frontend Integration

**Goal:** End-to-end application.

### Tasks

* Create Vue 3 app
* Configure Axios
* Create API client layer
* Build project & task UI
* Handle API errors

### Deliverables

* Fully working app
* Real frontend-backend interaction

---

## 🟢 Phase 7 — Refactoring & Cleanup

**Goal:** Improve maintainability.

### Tasks

* Extract services
* Reduce controller complexity
* Add logging
* Improve naming & structure

### Deliverables

* Cleaner architecture
* Same functionality

---

## 🟢 Phase 8 — Optional Enhancements

**Pick only 1–2:**

* Authentication (JWT)
* Tags
* Search
* Soft delete
* Hybrid SQL + NoSQL
* Dockerization

---

## 🛑 Explicitly Out of Scope

* Microservices
* CQRS / MediatR
* Event sourcing
* GraphQL
* Kubernetes

---

## 📌 Guiding Principles

* One feature at a time
* No abstraction without pain
* DTOs always
* Controllers stay thin
* Schema follows query needs
* Learning > perfection

---

## 🧭 Current Focus

You are currently transitioning to **MongoDB persistence**.

**Next immediate step:**
➡️ Phase 1 — MongoDB Integration

---

## ✅ End Goal

A realistic, maintainable backend project that:

* Demonstrates real-world backend skills
* Teaches NoSQL thinking
* Integrates cleanly with Vue
* Can evolve without rewrites
