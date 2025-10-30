# 🍽️ DineEase  
**2nd Year RAD Project | Built with Design Patterns**

DineEase is a C# (.NET Framework) desktop application developed as part of our 2nd-year **Rapid Application Development (RAD)** module.  
The system was designed to address the issue of **long queues at faculty canteen premises** by streamlining the food ordering and management process.  

---

## 🧠 Key Concepts & Design Patterns
We focused on applying **Software Design Patterns** to build a structured, scalable, and maintainable system.

- **Singleton Pattern**  
  Ensures a single, shared database connection instance throughout the application for efficient resource management.

- **Factory Method Pattern**  
  Dynamically creates instances based on user roles.  
  - If the username and password correspond to an *Admin*, it generates an Admin page instance.  
  - If the credentials match a *User*, it generates a User page instance.

---

## 💻 Tech Stack

| Layer | Technologies |
|-------|---------------|
| **Frontend / Backend** | C# (.NET Framework) |
| **IDE** | Visual Studio |
| **UI Framework** | Guna UI2 |
| **Database** | AWS Cloud (SQL Server) |
| **Version Control** | Git & GitHub |
| **Design Tool** | Figma |
| **Security** | SHA-256 encryption for password safety |

---

## 🗂️ Project Overview

### 🔸 Problem Statement
Since there is often a long queue to buy food at our university canteen, we decided to create a system that allows canteen admins and users to manage food availability, orders, and data more efficiently.

### 🔸 Solution
DineEase provides:
- Admin panel for managing food items and viewing reports.  
- User interface for viewing menus and placing orders.  
- Centralized database connection through Singleton.  
- Role-based UI control through Factory Method.  

---

## ⚙️ How It Works

1. The user logs in using their username and password.  
2. The system validates credentials using the database connection (Singleton).  
3. The Factory Method identifies the role:  
   - Admin → Loads Admin Dashboard  
   - User → Loads User Dashboard  
4. All password data is securely encrypted using **SHA-256**.

---

## 📂 Project Structure

- `DineEase\Program.cs` — app entry, loads `.env`, runs `Form1`
- `DineEase\ShowPageFactory.cs` — role-based page factory (`ADMIN` → `AdminViewOrdersnew`, `USER` → `userViewFoodnew`)
- `DineEase\config\Security.cs` — SHA-256 password hashing
- `DineEase\view\Signup.cs` — registration form with validation and insert to `Users`
- `DineEase\view\UserProfile.cs` — profile display/update and change password
- `DineEase\view\UserViewOrders.cs` — active orders list with cancel handling
- `DineEase\view\userViewFoodnew.cs` — food catalog with images (Guna UI2), navigation

Other referenced components you’ll need present in the project:
- `dao.DBConnection` (singleton providing `SqlConnection`)
- `CurrentUser` (holds `UserId` after login)
- Forms: `Form1` (login), `FoodDetails`, `ViewUserHistory`, `BlurForm`, `AdminViewOrdersnew`, `ChangePassword`
