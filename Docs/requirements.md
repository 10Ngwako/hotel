# Hotel Booking System – Requirements Specification

## 1. Overview

The Hotel Booking System is a web-based application designed to allow customers to search for hotel rooms, make reservations, and manage their bookings. Hotel staff and administrators can manage rooms, availability, and reservations through a secure interface.

The system is developed using **C#**, **ASP.NET Core Razor Pages**, and **.NET 9.0.0**, with **Visual Studio Code** as the development environment.

---

## 2. System Objectives

- Provide an easy-to-use platform for hotel room reservations
- Allow administrators to manage rooms, pricing, and availability
- Ensure accurate booking records and prevent double bookings
- Maintain secure user authentication and authorization
- Support maintainable and scalable application architecture

---

## 3. Functional Requirements

### 3.1 User Management

- Users shall be able to register an account
- Users shall be able to log in and log out
- Users shall be able to view and manage their profile
- The system shall support role-based access (Customer, Admin)

### 3.2 Room Management (Admin)

- Admin users shall be able to add new rooms
- Admin users shall be able to edit room details (type, price, capacity)
- Admin users shall be able to delete rooms
- Admin users shall be able to mark rooms as available or unavailable

### 3.3 Room Search and Availability

- Users shall be able to search for available rooms by date range
- Users shall be able to view room details and pricing
- The system shall prevent bookings for unavailable rooms
- The system shall display availability in real time

### 3.4 Booking Management

- Users shall be able to create a booking for an available room
- Users shall be able to view their booking history
- Users shall be able to cancel a booking (subject to policy)
- The system shall store booking dates, room details, and user information


---

## 4. Non-Functional Requirements

### 4.1 Performance

- The system shall respond to user actions within 2 seconds under normal load
- The system shall support multiple concurrent users

### 4.2 Security

- The system shall enforce authentication and authorization
- Passwords shall be securely hashed
- The system shall protect against common web vulnerabilities (e.g., SQL injection, CSRF)

### 4.3 Usability

- The user interface shall be intuitive and user-friendly
- The application shall be accessible through modern web browsers

### 4.4 Reliability

- The system shall ensure data consistency and integrity
- The system shall handle invalid input gracefully

### 4.5 Maintainability

- The codebase shall follow clean architecture and naming conventions
- The system shall be modular and easy to extend

---

## 5. Technical Requirements

### 5.1 Development Stack

- Programming Language: **C#**
- Framework: **ASP.NET Core Razor Pages**
- Runtime: **.NET 9.0.0**
- IDE: **Visual Studio Code**
- Version Control: **Git**

### 5.2 Architecture

- Razor Pages (PageModel pattern)
- MVC-style separation of concerns
- Dependency Injection for services
- Entity Framework Core 

### 5.3 Database 

- Relational database ( SQL Server, SQLite)
- Tables for Users, Rooms, Bookings
- Proper foreign key relationships

---

## 6. Assumptions and Constraints

- Users have internet access and a modern browser
- Initial release supports a single hotel location


---

## 7. Future Enhancements

- Multi-hotel support
- Email notifications and booking confirmations
- Advanced reporting and analytics
- Mobile-friendly responsive design

---

## 8. Glossary

- **Razor Pages**: ASP.NET Core feature for page-focused web applications
- **Booking**: A reservation made by a user for a hotel room
- **Admin**: User with privileges to manage system data
