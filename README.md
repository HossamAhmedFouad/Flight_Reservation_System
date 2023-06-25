# Flight Reservation System

This is a Flight Reservation System built with C# and MS SQL Server. It allows users to manage flights, aircrafts, and book flights for customers. The system also includes login functionality for both administrators and customers.

## Installation

1. Clone the repository to your local machine
2. Open the solution in Visual Studio
3. Build the solution to restore any NuGet packages
4. Create a new MS SQL Server database
5. Execute the SQL script (`FlightReservationSystem/SQLScripts/FlightReservation.sql`) to create the necessary tables and stored procedures
6. Update the connection string in the `Web.config` file to point to your new database
7. Run the application

## Usage

### Admin Login

As an admin, you can log in with the following credentials:

**Username:** admin

**Password:** admin

Once logged in, you can manage flights and aircrafts.

### Customer Login

As a customer, you can create a new account or log in with an existing one. After logging in, you can book flights.

### Creating SQL Queries

To create MS SQL Server queries, you can use the built-in query editor in Visual Studio. Simply right-click on the database connection in the Server Explorer and select "New Query". You can then write your queries in the editor and execute them against the database. You may need to modify the existing SQL connection to be suited to your own SQL Server
