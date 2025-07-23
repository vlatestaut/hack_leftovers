# BackOffice Blazor Server Application

This is a Blazor Server application with integrated GraphQL capabilities for managing workers and billing in a home care business.

## Features

- **Blazor Server UI**: Interactive web interface built with Blazor Server
- **GraphQL API**: Fully functional GraphQL endpoint with queries and mutations
- **Worker Management**: Create, read, update, and delete worker records
- **Interactive GraphQL Demo**: Built-in page to test GraphQL queries and mutations

## Getting Started

### Prerequisites
- .NET 8.0 SDK
- Visual Studio 2022 or VS Code

### Installation and Setup

1. Clone the repository
2. Navigate to the project directory:
   ```bash
   cd hack_leftovers
   ```

3. Restore NuGet packages:
   ```bash
   dotnet restore
   ```

4. Build the project:
   ```bash
   dotnet build
   ```

5. Run the application:
   ```bash
   dotnet run
   ```

The application will be available at `http://localhost:5000`

## GraphQL Integration

### GraphQL Endpoint
The GraphQL endpoint is available at: `http://localhost:5000/graphql`

### Available Operations

#### Queries
- `workers`: Get all workers
- `worker(id: Int!)`: Get a specific worker by ID
- `activeWorkers`: Get only active workers

#### Mutations
- `createWorker(input: CreateWorkerInput!)`: Create a new worker
- `updateWorker(id: Int!, input: UpdateWorkerInput!)`: Update an existing worker
- `deleteWorker(id: Int!)`: Delete a worker

### Sample GraphQL Queries

**Get all workers:**
```graphql
query {
  workers {
    id
    firstName
    lastName
    email
    position
    hourlyRate
    isActive
  }
}
```

**Create a new worker:**
```graphql
mutation {
  createWorker(input: {
    firstName: "Alice"
    lastName: "Johnson"
    email: "alice.johnson@example.com"
    phoneNumber: "555-0103"
    dateOfBirth: "1988-12-10"
    hireDate: "2024-01-01"
    position: "Care Coordinator"
    hourlyRate: 28.00
    isActive: true
  }) {
    id
    firstName
    lastName
    email
    position
  }
}
```

### Testing GraphQL

1. **Using the built-in demo page**: Navigate to `/graphql-demo` in the web application
2. **Using GraphQL Playground**: Visit `http://localhost:5000/graphql` in your browser
3. **Using tools like Postman**: Send POST requests to `http://localhost:5000/graphql`

## Project Structure

```
├── Models/                 # Data models (Worker, BillingRecord)
├── Services/              # Business logic services
├── GraphQL/               # GraphQL types, queries, and mutations
├── Pages/                 # Blazor pages and components
├── Shared/                # Shared components (NavMenu, Layout)
└── wwwroot/              # Static files (CSS, images)
```

## Technologies Used

- **ASP.NET Core 8.0**: Web framework
- **Blazor Server**: UI framework
- **Hot Chocolate**: GraphQL server implementation
- **Bootstrap**: CSS framework for styling
