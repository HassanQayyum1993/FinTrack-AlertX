# FinTrack-AlertX

**FinTrack-AlertX** is a real-time notification service for the **FinTrack** financial system. It supports multi-channel notifications (e.g., email, SMS, in-app) to alert users of critical events, such as transaction declines, unusual account activity, or system downtime. This project is built using .NET 8, Docker, RabbitMQ, SQL Server, and MongoDB, and allows users to customize notification preferences and track message status.

## Features

- Real-time notifications for critical events
- Multi-channel delivery options (email, SMS, in-app)
- User-customizable notification preferences
- Read/unread message tracking
- Reliable and scalable message processing

## Technology Stack

- **Backend**: .NET 8, ASP.NET Core
- **Queue Management**: RabbitMQ
- **Database**: SQL Server (for user and notification data) & MongoDB (for logging and analytics)
- **Containerization**: Docker

## Getting Started

### Prerequisites

- Docker & Docker Compose
- .NET SDK 8.0 (if running locally outside of Docker)
- SQL Server Management Studio (for database management)
- MongoDB Compass (for MongoDB management)

### Setup

1. **Clone the Repository**
   ```bash
   git clone https://github.com/your-username/FinTrack-AlertX.git
   cd FinTrack-AlertX
Configure Connection Strings

In appsettings.json, update the connection strings as follows:

json
Copy code
"ConnectionStrings": {
  "SqlServer": "Server=sqlserver,1433;Database=FinTrackDB;User Id=sa;Password=YourPassword;",
  "MongoDB": "mongodb://mongodb:27017/FinTrackDB"
}
Run Docker Compose

Use Docker Compose to build and run the application along with SQL Server, RabbitMQ, and MongoDB.

bash
Copy code
docker-compose up --build
Access the Application

API: http://localhost:5000
Swagger UI: http://localhost:5000/swagger - for testing API endpoints
RabbitMQ Management: http://localhost:15672 (username: guest, password: guest)
Usage
Testing the API
To test the endpoints, open Swagger UI or use a tool like Postman. Available endpoints include:

POST /api/notifications - Send a new notification.
GET /api/notifications/{userId} - Retrieve notifications for a specific user.
PUT /api/notifications/{notificationId}/read - Mark a notification as read.
Database Management
SQL Server: Connect to the SQL Server instance via SQL Server Management Studio using localhost,1433 as the server name.
MongoDB: Connect using MongoDB Compass to view and manage collections at localhost:27017.
Project Structure
bash
Copy code
FinTrack-AlertX
├── Data                    # Database context and migrations
├── Repositories            # Data repositories for SQL and MongoDB
├── Services                # Notification and message queue services
├── Controllers             # API controllers
├── docker-compose.yml      # Docker configuration
├── FinTrack.AlertX.sln     # Solution file
└── README.md               # Project documentation
