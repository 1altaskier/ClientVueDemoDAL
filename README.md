# ClientVueDemoDAL

This project serves as the backend API and data access layer for managing client information and their associated phone numbers. Built with ASP.NET Core and Entity Framework Core, it powers the ClientVueDemoUX frontend.

---

## 🧱 Tech Stack

- ASP.NET Core 7+
- Entity Framework Core
- SQL Server (or other provider via EF Core)
- C#
- RESTful API

---

## 📁 Project Structure

PorchFinal.DAL/
├── Controllers/
│ └── ClientsController.cs
│ └── PhoneTypesController.cs
├── Models/
│ └── Client.cs
│ └── Phone.cs
│ └── PhoneType.cs
├── DTOs/
│ └── ClientReadDto.cs
│ └── ClientUpdateDto.cs
├── Data/
│ └── ApplicationDbContext.cs
├── Program.cs
├── appsettings.json

## 🛠️ Setup Instructions

1. **Clone the Repository**:

```bash
git clone https://github.com/1altaskier/ClientVueDemoDAL.git
cd ClientVueDemoDAL
```
Configure the Database
Update appsettings.json with your connection string.

---

🌐 API Endpoints
Method	Endpoint	Description
GET	/api/Clients	Get all clients
GET	/api/Clients/{id}	Get a single client
POST	/api/Clients	Create new client
PUT	/api/Clients/{id}	Update client info
GET	/api/PhoneTypes	Get all phone types

