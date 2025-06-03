# Product API Microservice

## Overview

This is a .NET 9 Web API microservice for managing products in an e-commerce system. It provides endpoints for CRUD operations, filtering, and integrates with a SQL Server database. The project follows clean architecture principles, separating core logic, infrastructure, and API layers.

## Features

- RESTful API for product management (Create, Read, Update, Delete)
- Filtering products by name
- Data validation with FluentValidation
- AutoMapper for DTO mapping
- Exception handling middleware
- Swagger/OpenAPI documentation
- Docker support for containerized deployment
- CORS enabled for frontend integration

## Tech Stack

- .NET 9 (ASP.NET Core)
- Entity Framework Core
- SQL Server
- AutoMapper
- FluentValidation
- Docker

## Project Structure

- `Product.API/` - API layer (controllers, startup, middleware)
- `Core/` - Domain models, DTOs, services, contracts, validators, mappers
- `Infrastructure/` - Data access, repositories, EF Core context, migrations

## Getting Started

1. **Clone the repository**
   ```bash
   git clone <your-repo-url>
   cd Product-API-microservice
   ```

2. **Configure the database**
   - Update the connection string in `Product.API/appsettings.json` if needed.

3. **Run database migrations**
   ```bash
   dotnet ef database update --project Infrastructure
   ```

4. **Run the API**
   ```bash
   dotnet run --project Product.API
   ```

5. **Access Swagger UI**
   - Navigate to `http://localhost:5000/swagger` (or the port shown in your console).

6. **Docker (optional)**
   ```bash
   docker build -t product-api .
   docker run -p 8080:8080 product-api
   ```

## API Endpoints

- `POST /api/product` - Create a new product
- `GET /api/product` - Get all products
- `GET /api/product/filter?productName=...` - Filter products by name
- `GET /api/product/{id}` - Get product by ID
- `PUT /api/product/{id}` - Update product by ID
- `DELETE /api/product/{id}` - Delete product by ID

## Example Product Model

```json
{
  "productId": "guid",
  "productName": "string",
  "category": "string",
  "unitPrice": 0.0,
  "quantityInStock": 0
}
``` 