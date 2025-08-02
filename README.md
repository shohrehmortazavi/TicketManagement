# 🎫 Offline Ticketing System API

## 📌 Description
A simple offline ticketing system API designed for an organization.  
Employees can create support tickets, and admins can manage and track them.  
Basic ticket statistics are also available for admins.

---

## ✅ Requirements

### 1. User Accounts & Roles
- Two user roles:
  - **Employee**
  - **Admin**
- Each user has:
  - `Id` (GUID)
  - `FullName`
  - `Email`
  - `Password` (securely stored; e.g., hashed)
  - `Role` (enum or string)

- **Authentication**
  - JWT-based authentication
  - Endpoint: `POST /auth/login` – authenticate and receive a token
  - All endpoints are protected based on roles

---

### 2. Ticketing System

Each ticket includes:
- `Id` (GUID)
- `Title`
- `Description`
- `Status`: `Open`, `InProgress`, `Closed`
- `Priority`: `Low`, `Medium`, `High`
- `CreatedAt` (datetime)
- `UpdatedAt` (datetime)
- `CreatedByUserId` (FK to User)
- `AssignedToUserId` (nullable FK to Admin)

---

### 3. API Endpoints

#### 🔐 Authentication
- `POST /auth/login` – Login with email and password

#### 🎟️ Ticket Management
- `POST /tickets` – Create a new ticket (**Employee only**)
- `GET /tickets/my` – List tickets created by the current user (**Employee**)
- `GET /tickets` – List all tickets (**Admin only**)
- `PUT /tickets/{id}` – Update ticket status and assignment (**Admin only**)
- `GET /tickets/stats` – Show ticket counts by status (**Admin only**)
- `GET /tickets/{id}` – Get a specific ticket’s details (allowed to **creator** and **assigned admin**)
- `DELETE /tickets/{id}` – Delete a ticket (**Admin only**)

---

## 🚀 Tech Stack
- ASP.NET Core Web API
- JWT Authentication
- Entity Framework Core
- MSSQL
- MediateR
- CQRS

---

## ✍️ Author
Shohreh Mortazavi  
📧 [MortazaviDev@gmail.com]  
🌐 [https://www.linkedin.com/in/shohreh-mortazavi]

