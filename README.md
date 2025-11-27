# Healthcare Management System  
A full-stack, multi-role web application for managing core clinic operations such as patient records, appointments, doctor schedules, and administrative tasks.

##  Overview
The **Healthcare Management System** is designed to streamline the workflow of small and medium-sized clinics.  
It supports **role-based access** for Admin, Doctor, and Receptionist users, ensuring secure and organized management of clinic activities.

This project was developed by a team, with me as the **team lead**, focusing on full-stack development, architecture, Git collaboration, and clean code practices.

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

##  Features

###  **Role-Based Authentication**
- Admin, Doctor, Receptionist roles  
- Secure JWT-based login  
- Route guards on the frontend  

###  **Admin Features**
- Manage doctors  
- Manage receptionist/staff accounts  
- View clinic-wide analytics (if applicable)

###  **Receptionist Features**
- Add/View/Edit patients  
- Schedule and manage appointments  
- Check doctor availability  
- Simple dashboard

###  **Doctor Features**
- View assigned appointments  
- View patient details  
- Update consultation notes (if added)

### ⚙️ **General System Features**
- Reusable UI components  
- Clean and structured API  
- Centralized error handling  
- Logging (if implemented)  
- Fully modular Angular structure  

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

##  Running the Project

### **Backend**
1. Clone the repository  
2. Update the database connection string in `appsettings.json`  
3. Run migrations: `update-database`
4. 4. Start the API:  

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

##  License
Open-source for learning and portfolio purposes.


