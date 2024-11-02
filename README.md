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
