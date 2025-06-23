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
git clone https://github.com/1altaskier/PorchFinal.DAL.git
cd PorchFinal.DAL
```
