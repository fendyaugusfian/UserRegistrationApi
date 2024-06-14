
# User Registration API - Backend (.NET Core)

This repository contains the backend API for the User Registration App built with .NET Core.

## Prerequisites

Before you begin, ensure you have met the following requirements:
- .NET Core SDK installed on your development machine
- A compatible IDE (e.g., Visual Studio, Visual Studio Code)

## Getting Started

To get a local copy up and running follow these simple steps:

1. **Clone the repository**:
   git clone <repository_url>
   cd UserRegistrationApi
   
2. **Configure the database connection**:
   Update the database connection string in appsettings.json to point to your SQL Server instance.

3. **Run migrations**:
   dotnet ef database update
   
5. **Run the API**:
   dotnet run

## Access API endpoints:
Open http://localhost:5093/api/users in your web browser or a tool like Postman.

## Access Swagger :
Open http://localhost:5093/swagger/index.html.

## License
This project is licensed under the MIT License.
