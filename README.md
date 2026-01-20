# Gym Manager System

A comprehensive Windows Forms desktop application for managing gym operations, including members, subscriptions, classes, instructors, rooms, and bookings.

## Overview

Gym Manager System is a full-featured management solution built with C# and Windows Forms. It provides an intuitive interface for gym administrators to manage all aspects of their facility operations, from member registration to class scheduling and attendance tracking.

## Features

### Member Management
- Add, edit, and delete member records
- Track member information including contact details, date of birth, and emergency contacts
- Store medical notes for members
- Manage member status (active, inactive, suspended)
- View member join dates and history

### Membership Plans
- Create and manage membership plans with customizable pricing
- Set plan duration in months
- Configure maximum classes per month per plan
- Activate or deactivate plans
- Track plan descriptions and details

### Subscriptions
- Assign membership plans to members
- Track subscription start and end dates
- Manage subscription status (active, expired, paused, cancelled)
- Monitor payment status
- Renew subscriptions automatically or manually
- Filter subscriptions by member

### Instructor Management
- Maintain instructor profiles with contact information
- Track instructor certifications and specializations
- Manage instructor status (active, inactive)
- Record hire dates
- View instructor details and qualifications

### Room Management
- Manage gym rooms and facilities
- Set room capacity limits
- Track available equipment in each room
- Monitor room status (available, maintenance, closed)
- View room creation dates

### Class Management
- Create class instances manually or generate from schedules
- Schedule classes with specific dates and times
- Assign instructors and rooms to classes
- Set class capacity and track current bookings
- Manage class status (scheduled, in_progress, completed, cancelled)
- Filter classes by date range

### Booking Management
- Members can book classes
- View all bookings with member and class details
- Track booking status (confirmed, cancelled, no_show)
- Filter bookings by member
- Monitor booking timestamps

### Attendance Tracking
- Record member attendance for classes
- Track check-in times
- Mark attendance status
- Add notes for attendance records

## Technology Stack

- **Framework**: .NET 8.0
- **UI**: Windows Forms
- **Database**: MySQL
- **Architecture**: Repository Pattern with Service Layer
- **Language**: C#

## Project Structure

```
Gym-Manager-System/
├── DataFolder/
│   └── DatabaseContext.cs          # Database connection management
├── Forms/                           # Windows Forms UI
│   ├── MainForm.cs                  # Main application window
│   ├── MembersForm.cs               # Member management
│   ├── SubscriptionsForm.cs         # Subscription management
│   ├── ClassesForm.cs               # Class management
│   ├── BookingsForm.cs              # Booking management
│   ├── InstructorsForm.cs           # Instructor management
│   ├── RoomsForm.cs                 # Room management
│   └── MembershipPlansForm.cs      # Plan management
├── Model/                           # Data models
│   ├── Member.cs
│   ├── Subscription.cs
│   ├── ClassInstance.cs
│   ├── Booking.cs
│   ├── Instructor.cs
│   ├── Room.cs
│   └── MembershipPlan.cs
├── Repositories/                    # Data access layer
│   ├── Interfaces/                  # Repository interfaces
│   └── Concrete/                    # Repository implementations
└── Services/                        # Business logic layer
    ├── Interfaces/                  # Service interfaces
    └── Concrete/                    # Service implementations
```

## Prerequisites

- Windows operating system
- .NET 8.0 SDK or Runtime

## Installation

1. Clone the repository:
```
git clone https://github.com/sondaydungso/Gym-Manager-System
cd Gym-Manager-System
```

2. Set up the database (optional, you can use my database tho :) )
   - Create a MySQL database named `gym_management_system`
   - Execute the SQL script `gym_manager.sql` to create all required tables
   - Ensure your MySQL user has appropriate permissions

3. Configure database connection: (do not modify anything if you use my database)
   - Open `Forms/MainForm.cs`
   - Update the connection string in the `InitializeServices()` method with your database credentials:
   ```csharp
   var connectionString = "Server=YOUR_SERVER;Database=gym_management_system;UserID=YOUR_USER;Password=YOUR_PASSWORD;";
   ```

4. Build the project:
```
dotnet build
```

5. Run the application:
```
dotnet run
```

Or open the solution file `Gym Manager System.sln` in Visual Studio and run it from there.

## Database Schema

The system uses the following main tables:

- **members**: Stores member information
- **membership_plans**: Defines available membership plans
- **subscriptions**: Links members to membership plans
- **instructors**: Stores instructor details
- **rooms**: Manages gym rooms and facilities
- **class_types**: Defines types of classes offered
- **class_schedules**: Recurring class schedules
- **class_instances**: Individual class sessions
- **bookings**: Member class bookings
- **attendance**: Attendance records for classes

## Usage

### Starting the Application

1. Launch the application
2. The system will attempt to connect to the database
3. If connection fails, you'll be prompted with options to continue or exit

### Managing Members

1. Navigate to **Members > View Members**
2. Click **Add Member** to create a new member
3. Fill in member details including name, email, phone, and emergency contact
4. Use **Edit Member** to update existing member information
5. Use **Delete Member** to remove a member (this will also delete associated subscriptions and bookings)

### Managing Membership Plans

1. Navigate to **Plans > View Plans**
2. Click **Add Plan** to create a new membership plan
3. Set plan name, duration, price, and maximum classes per month
4. Plans are automatically set as active when created
5. Edit or delete plans as needed

### Managing Subscriptions

1. Navigate to **Subscriptions > View Subscriptions**
2. Click **Add Subscription** to assign a plan to a member
3. Select a member and a membership plan
4. Set the subscription start date
5. The end date is automatically calculated based on plan duration
6. Use **Renew** to extend an existing subscription
7. Use **Cancel** to cancel a subscription

### Managing Instructors

1. Navigate to **Instructors > View Instructors**
2. Click **Add Instructor** to add a new instructor
3. Enter instructor details including certifications and specializations
4. Edit or delete instructor records as needed

### Managing Rooms

1. Navigate to **Rooms > View Rooms**
2. Click **Add Room** to create a new room
3. Set room name, capacity, and equipment available
4. Update room status (available, maintenance, closed) when editing
5. Delete rooms that are no longer in use

### Managing Classes

1. Navigate to **Classes > View Classes**
2. Use date filters to view classes within a specific range
3. Click **Add Class** to manually create a class instance
4. Select date, time, instructor, room, and set capacity
5. Use **Generate from Schedule** to automatically create classes based on recurring schedules
6. View class details including current bookings and status

### Managing Bookings

1. Navigate to **Bookings > View Bookings**
2. Filter bookings by member if needed
3. Click **Add Booking** to create a new booking
4. Select a member and an available class
5. View booking status and timestamps

## Architecture

The application follows a layered architecture:

- **Presentation Layer**: Windows Forms for user interface
- **Service Layer**: Business logic and validation
- **Repository Layer**: Data access abstraction
- **Data Layer**: MySQL database

This architecture provides:
- Separation of concerns
- Testability
- Maintainability
- Scalability

## Configuration

### Database Connection

The database connection string is configured in `Forms/MainForm.cs` within the `InitializeServices()` method. Update this with your MySQL server details:

```csharp
var connectionString = "Server=YOUR_SERVER;Database=gym_management_system;UserID=YOUR_USER;Password=YOUR_PASSWORD;";
```

### Default Settings

- Default member status: Active
- Default room status: Available
- Default instructor status: Active
- Default class status: Scheduled
- Default subscription status: Active

## Troubleshooting

### Database Connection Issues

If you encounter database connection errors:

1. Verify MySQL server is running
2. Check database credentials in the connection string
3. Ensure the database `gym_management_system` exists
4. Verify user permissions for the database
5. Check firewall settings for port 3306

### Class Creation Errors

If you get foreign key constraint errors when creating classes:

- Ensure the database schema allows NULL values for `schedule_id` in `class_instances` table
- Manual classes (not from schedule) use NULL for schedule_id

### No Plans Available

If membership plans don't appear in subscription forms:

- Navigate to **Plans > View Plans** and create at least one active plan
- Plans must be active (`is_active = 1`) to appear in subscription forms

## Development

### Adding New Features

1. Create model classes in the `Model/` folder
2. Create repository interfaces in `Repositories/Interfaces/`
3. Implement repositories in `Repositories/Concrete/`
4. Create service interfaces in `Services/Interfaces/`
5. Implement services in `Services/Concrete/`
6. Create forms in the `Forms/` folder
7. Add menu items in `MainForm.Designer.cs` and handlers in `MainForm.cs`

### Code Style

- Follow C# naming conventions
- Use async/await for database operations
- Implement proper error handling
- Use repository pattern for data access
- Keep business logic in service layer

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Support

For issues, questions, or contributions, please open an issue in the repository.

## Version History

- Version 1.0: Initial release with core functionality
  - Member management
  - Subscription management
  - Class and booking management
  - Instructor and room management
  - Membership plan management

## Future Enhancements

Potential features for future versions:

- Payment processing integration
- Email notifications
- Reporting and analytics
- Member portal
- Mobile app support
- Multi-location support
- Advanced scheduling features
- Equipment maintenance tracking

