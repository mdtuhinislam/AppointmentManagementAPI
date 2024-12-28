# Appointment Management API
This repository contains the Appointment Management API, a .NET-based application designed to manage user authentication and appointment scheduling.

Features
User Registration and Authentication: Users can register and log in to obtain a JWT token for authorized access.
Appointment Management: Authenticated users can create, retrieve, update, and delete appointments.
Prerequisites
.NET 6 SDK
SQL Server
Getting Started
Clone the repository:

bash
Copy code
git clone https://github.com/mdtuhinislam/AppointmentManagementAPI.git
cd AppointmentManagementAPI
Set up the database:

Update the connection string in appsettings.json to point to your SQL Server instance.

Apply migrations to set up the database schema:
**Select AppointmentManagementAPI.Infrastructure project to the console manager and run command "update-database"**

bash
Copy code
dotnet ef database update
Run the application:

bash
Copy code
dotnet run

API Endpoints
Authentication
Register: POST /api/auth/register
Login: POST /api/auth/login
Appointments
Create Appointment: POST /api/appointments
Get All Appointments: GET /api/appointments
Get Appointment by ID: GET /api/appointments/{id}
Update Appointment: PUT /api/appointments
Delete Appointment: DELETE /api/appointments/{id}
Note: All appointment-related endpoints require a valid JWT token in the Authorization header.

License
This project is licensed under the MIT License. See the LICENSE file for details.

Contact
For any inquiries or support, please contact mdtuhinislam.
