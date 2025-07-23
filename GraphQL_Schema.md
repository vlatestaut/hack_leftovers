# GraphQL Schema Documentation

This document describes the expected GraphQL schema for the Clinical Input Console integration.

## Required GraphQL Server Endpoint
- URL: `http://localhost:5001/graphql` (configurable in appsettings.json)

## Expected Schema

### Types

```graphql
type ClinicalInputData {
  patientId: String!
  patientName: String!
  dateOfBirth: String!
  gender: String!
  phoneNumber: String
  address: String
  city: String
  state: String
  zipCode: String
  emergencyContact: String
  emergencyPhone: String
  primaryPhysician: String
  diagnosis: String
  medications: String
  allergies: String
  notes: String
  admissionDate: String!
  insuranceProvider: String
  insurancePolicyNumber: String
  priority: String
  isActive: Boolean!
}

type ClinicalInputResponse {
  success: Boolean!
  message: String!
  patientId: String
}

input ClinicalInputDataInput {
  patientId: String!
  patientName: String!
  dateOfBirth: String!
  gender: String!
  phoneNumber: String
  address: String
  city: String
  state: String
  zipCode: String
  emergencyContact: String
  emergencyPhone: String
  primaryPhysician: String
  diagnosis: String
  medications: String
  allergies: String
  notes: String
  admissionDate: String!
  insuranceProvider: String
  insurancePolicyNumber: String
  priority: String
  isActive: Boolean!
}
```

### Queries

```graphql
type Query {
  # Get a specific patient by ID
  patient(id: String!): ClinicalInputData
  
  # Search patients by name or ID
  searchPatients(searchTerm: String!): [ClinicalInputData!]!
}
```

### Mutations

```graphql
type Mutation {
  # Save or update patient data
  savePatientData(input: ClinicalInputDataInput!): ClinicalInputResponse!
}
```

## Example Queries

### Get Patient by ID
```graphql
query GetPatient {
  patient(id: "P001") {
    patientId
    patientName
    dateOfBirth
    gender
    phoneNumber
    diagnosis
    isActive
  }
}
```

### Search Patients
```graphql
query SearchPatients {
  searchPatients(searchTerm: "John") {
    patientId
    patientName
    dateOfBirth
    phoneNumber
  }
}
```

### Save Patient Data
```graphql
mutation SavePatient {
  savePatientData(input: {
    patientId: "P001"
    patientName: "John Doe"
    dateOfBirth: "1980-01-01"
    gender: "Male"
    phoneNumber: "555-123-4567"
    admissionDate: "2025-07-23"
    isActive: true
  }) {
    success
    message
    patientId
  }
}
```

## Implementation Notes

1. The Blazor application expects the GraphQL server to be running on `http://localhost:5001/graphql`
2. All date fields should be in ISO 8601 format (YYYY-MM-DD)
3. The GraphQL server should handle CORS for the Blazor application
4. Error handling should return appropriate HTTP status codes and error messages
5. Patient IDs should be unique strings
6. The search functionality should perform case-insensitive matching on patient names and IDs
