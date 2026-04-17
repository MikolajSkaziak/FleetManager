# FleetManager

## Key Features

* **Fleet Management**: Full CRUD operations for vehicles (Motorcycle, Car, Truck, Bus).
* **Driver Registry**: Manage drivers with support for multiple driving license categories (A, B, C, D).
* **Smart Trip Logging**: Automated validation of driver permissions against vehicle types.
* **Robust Error Handling**: Global exception middleware for consistent API responses and fail-safe operation.
* **Persistence**: Entity Framework Core integration with SQL Server (data persists after restart).
* **Interactive Documentation**: Integrated Scalar/Swagger UI for easy API testing.

## Tech Stack

* **Backend**: .NET 10 / ASP.NET Core Web API
* **Database**: Entity Framework Core / SQL Server
* **Testing**: xUnit

## Architecture & Design Decisions

### 1. Service Layer Pattern
Business logic is decoupled from Controllers. The `TripService` coordinates the flow between the database and validation rules, ensuring "Thin Controllers" and high testability.

### 2. Strategy-based License Validation
The `LicenseValidator` is an isolated component responsible for checking if a driver can operate a specific vehicle. It uses bitwise flags for handling multiple license categories efficiently.

### 3. Global Exception Middleware
Instead of cluttered `try-catch` blocks in every controller, a custom middleware handles all exceptions globally. This ensures thatn even during a database failure, the API returns a JSON response.

## API Endpoints

### Vehicles
* `GET /api/Vehicles` - List all vehicles
* `POST /api/Vehicles` - Add new vehicle (Model, Brand, Plate, Type)
* `PUT /api/Vehicles/{id}` - Update vehicle (Model, Brand, Plate, Type)
* `DELETE /api/Vehicles/{id}` - Delete vehicle 
### Drivers
* `GET /api/drivers` - List all drivers
* `POST /api/drivers` - Add new driver (Name, Surname, License categories)
* `PUT /api/Drivers/{id}` - Update driver (Name, Surname, License categories)
* `DELETE /api/Drivers/{id}` - Delete driver 

### Trips
* `GET /api/trips` - View trip history (including full driver and vehicle details)
* `POST /api/trips` - Log a new trip (Includes validation: License must match Vehicle Type)

## Testing

The project includes a suite of **Unit Tests** focused on the core business logic:
* Validation of driving licenses (A, B, C, D) against all vehicle types.
* Validation of trip chronology (StartTime < EndTime).

To run the tests:
```bash
dotnet test