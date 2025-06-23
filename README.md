# Job Board Platform

A full-stack Job Board platform built with:
- Frontend: Vue 3 + Vite + Vue Router + Pinia + Vuetify
- Backend: .NET 8 Web API + SQLite + Entity Framework Core
- Auth: JWT-based authentication with role separation (Admin and Candidate)

---

## Features

### Candidate
- Register and log in with the role of the Candidate
- View list of jobs
- Apply to jobs with a message
- View personal applications

### Admin
- Register and log in with role = Admin
- Create, edit, delete jobs
- View candidates that applied to specific jobs

---
The app currently does not have Docker
## Getting Started

### Backend Setup
1. Navigate to backend folder:
   ```bash
   cd JobBoard.Backend
   ```

2. Run the app:
   ```bash
   dotnet run
   ```

3. API is hosted at: http://localhost:5001/api 

### Frontend Setup
1. Navigate to frontend folder:
   ```bash
   cd JobBoard.Frontend
   ```

2. Install dependencies:
   ```bash
   npm install
   ```

3. Start the app:
   ```bash
   npm run dev
   ```

4. App runs at:
   ```
   http://localhost:5173
   ```

---

## Default Admin User (seeded)
```
Email: admin@example.com
Password: admin123
```

---

## Tech Stack
 Frontend   : Vue 3, Vite, Vuetify  
 State      : Pinia                 
 Auth       : JWT                   
 Backend    : .NET 8 Web API        
 DB         : SQLite + EF Core      
 ORM        : Entity Framework Core 
 Styling    : Vuetify               

