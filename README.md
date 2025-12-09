# Healthcare Management System  
A full-stack, multi-role web application for managing core clinic operations such as patient records, appointments, doctor schedules, and administrative tasks.

##  Overview
The **Healthcare Management System** is designed to streamline the workflow of small and medium-sized clinics.  
It supports **role-based access** for Admin, Doctor, and Receptionist users, ensuring secure and organized management of clinic activities.

This project was developed by a team, with me as the **team lead**, focusing on full-stack development, architecture, Git collaboration, and clean code practices.

---
##  Objectives

| Goal | Description |
|------|-------------|
| Centralization | Combine major clinic operations into one system. |
| Patient Experience | Provide access to appointments, lab reports, and prescriptions. |
| Collaboration | Improve communication between clinical staff. |
| Security | Protect patient health information (PHI). |

---
##  Tech Stack

### **Frontend**
- Angular  
- TypeScript  
- Angular Routing & Forms  
- Bootstrap / Tailwind (choose whichever you used)

### **Backend**
- ASP.NET Core Web API  
- Entity Framework Core  
- SQL Server  
- Repository Pattern (if used)  
- DTOs & Model Validation  
- JWT Authentication (if implemented)

### **Database**
- Microsoft SQL Server  
- Tables for Patients, Doctors, Appointments, Users, Roles, etc.

---

## Features by Role

### **Admin**
| Feature | Description |
|---------|-------------|
| User Management | Create/update users & roles (RBAC). |
| Master Data | Manage departments, lab tests, medicines. |
| Reporting | Operational & revenue reports. |
| Auditing | Logs for all CRUD operations. |

### **Receptionist**
| Feature | Description |
|---------|-------------|
| Patient Registration | Add & update patient details. |
| Appointment Scheduling | Book, edit, cancel, queue handling. |
| Billing | Generate invoices & record payments. |

### **Doctor**
| Feature | Description |
|---------|-------------|
| Appointments | View & manage daily schedule. |
| SOAP Notes | Record subjective, objective, assessment, plan. |
| E-Prescriptions | Issue digital prescriptions. |
| Lab Orders | Request lab tests and review results. |

### **Pharmacist**
| Feature | Description |
|---------|-------------|
| Prescription Handling | Verify and dispense medicines. |
| Inventory | Manage stock, batch numbers, expiry. |
| Purchase Orders | Handle procurements. |

### **Lab Technician**
| Feature | Description |
|---------|-------------|
| Lab Orders | Receive and process test orders. |
| Sample Tracking | Manage collection and workflow. |
| Lab Results | Enter & validate results. |

### ⚙️ **General System Features**
- Reusable UI components  
- Clean and structured API  
- Centralized error handling  
- Logging (if implemented)  
- Fully modular Angular structure  

---
## Architecture Overview

Angular Frontend
↓
ASP.NET Core API Controllers
↓
Services (Business Logic)
↓
Repositories
↓
Entity Framework Core
↓
SQL Server

---
##  Project Structure

### **Backend**
/HealthcareManagement.API
/Controllers
/Models
/DTOs
/Repositories
/Services
/Migrations
appsettings.json
Program.cs


### **Frontend**
/src/app
/components
/admin
/doctor
/receptionist
/shared
/services
/models
/guards

---
## Database Structure (High Level)

### Core Tables

| Table | Purpose |
|--------|---------|
| **Users** | Staff information (Name, Email, Phone, PasswordHash, RoleId). |
| **Roles** | RBAC role definitions. |
| **Patients** | Patient demographics. |
| **Appointments** | Scheduling records. |
| **Consultations** | SOAP notes and history. |
| **Medicines** | Medicine master + inventory. |
| **Prescriptions** | Items prescribed by doctors. |
| **LabTests** | Test definitions + metadata. |
| **LabResults** | Released lab results. |
| **Billing** | Invoices and payments. |

---
## Non-Functional Requirements

### **Security**

| Requirement | Details |
|-------------|---------|
| Encryption | AES-256 for PHI at rest (if used). |
| Authentication | JWT-based login. |
| Authorization | Strict RBAC per module. |
| Audit Logging | Logged on all CRUD actions. |

### **Performance**

| Requirement | Target |
|-------------|--------|
| API Response | < 2 seconds |
| Concurrency | 500+ users |

### **Availability**

| Requirement | Target |
|-------------|--------|
| Uptime | 99.9% |
| Database Backups | Automated daily backup |

---

##  Running the Project

### **Backend**
1. Clone the repository  
2. Update the database connection string in `appsettings.json`  
3. Run migrations: `update-database`
4.  Start the API:  

### **Frontend**
1. Navigate to the Angular project folder  
2. Install dependencies:  `npm install`
3.  Run the app:  `npm start`
4. Open in browser:  `http://localhost:4200`

---

##  Screenshots
(Add your screenshots here once UI is ready.)

---

##  Team & Collaboration
This project was developed collaboratively with:
- Git branching strategy  
- Pull requests and code reviews  
- Shared task board (Kanban)  
- Clear role distribution  

I served as the **Team Lead**, responsible for:
- Architecture planning  
- Backend development  
- Coordinating Git workflow  
- Integrating frontend–backend modules  
- Ensuring project consistency and deadlines

---
## Team

| Role         | Member                                             |
| ------------ | -------------------------------------------------- |
| Team         | Unhackables                                        |
| Contributors | Preethu Pradeep, Chythra Raj, Libiya JM, Anjali VB |
| Reviewer     | Sahadan Sir                                        |

---
##  License
Open-source for learning and portfolio purposes.


