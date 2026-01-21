# Hotel Booking System – Requirements

## 1. Overview

The Hotel Booking System is a web-based application developed using C# and .NET 9.0.  
It allows customers to search for hotels and rooms, make reservations, and manage bookings, while enabling administrators to manage hotels, rooms, pricing, and availability.

## 2. Objectives

- Provide an easy-to-use platform for hotel room bookings
- Ensure accurate availability and pricing management
- Support secure user authentication and data handling
- Enable administrators to manage hotel-related data efficiently

## 3. Stakeholders

- Customers (guests)
- Hotel administrators
- System administrators
- Developers and maintainers

## 4. Functional Requirements

### 4.1 User Management
- Users shall be able to register and log in
- Users shall be able to view and update their profile
- The system shall support role-based access (Customer, Admin)

### 4.2 Hotel & Room Management
- Admins shall be able to create, update, and delete hotels
- Admins shall be able to manage room types, prices, and availability
- The system shall prevent double-booking of rooms

### 4.3 Booking Management
- Users shall be able to search for available rooms by date and location
- Users shall be able to create a booking
- Users shall be able to view and cancel their bookings
- The system shall calculate total booking cost automatically


## 5. Non-Functional Requirements

### 5.1 Performance
- The system should support concurrent users without performance degradation
- Search results should be returned within an acceptable response time

### 5.2 Security
- User passwords shall be securely hashed
- Authentication shall be handled using industry-standard mechanisms
- Sensitive data shall be protected against unauthorized access

### 5.3 Reliability & Availability
- The system should be available 24/7
- The system should handle failures gracefully

### 5.4 Maintainability
- Code should be modular and testable

## 6. Assumptions & Constraints

- The application is built using C# and .NET 9.0
- A relational database is used for data storage
- The system is deployed in a web environment
