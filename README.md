# BackOffice.Blazor - Clinical Input Console

This is a Blazor Server application built with .NET 8 that includes a comprehensive Clinical Input Console form converted from WinForms to Blazor. The application uses GraphQL for data operations and follows Blazor Server best practices.

## Features

### Clinical Input Console Form
- **Comprehensive Patient Data Entry**: Complete form for entering patient demographics, medical information, insurance details, and clinical notes
- **Real-time Validation**: Built-in form validation using Data Annotations
- **Patient Search**: Search functionality to find existing patients by ID or name
- **Responsive Design**: Mobile-friendly interface using Bootstrap 5
- **GraphQL Integration**: Uses GraphQL client for all data operations

### Components Used
- **CustomButton**: Reusable button component with various styles and icons
- **CustomInput**: Flexible input component supporting text, select, textarea, and date inputs
- **Bootstrap 5**: Modern responsive UI framework
- **Font Awesome Icons**: Professional iconography

## Project Structure
```
BackOffice.Blazor/
├── Components/
│   ├── CustomButton.razor      # Reusable button component
│   └── CustomInput.razor       # Reusable input component
├── Models/
│   └── ClinicalData.cs         # Data models for clinical information
├── Pages/
│   ├── ClinicalInputConsole.razor  # Main clinical form page
│   ├── Index.razor             # Home page
│   ├── About.razor             # About page
│   └── _Host.cshtml            # Host page with styles and scripts
├── Services/
│   └── ClinicalGraphQLService.cs   # GraphQL service for data operations
├── Shared/
│   ├── MainLayout.razor        # Main layout component
│   └── NavMenu.razor           # Navigation menu
├── wwwroot/
│   ├── css/
│   │   └── clinical.css        # Custom styles for clinical forms
│   └── Images/                 # Static images
├── _Imports.razor              # Global using statements
├── Program.cs                  # Application entry point
├── appsettings.json           # Configuration including GraphQL endpoint
└── GraphQL_Schema.md          # GraphQL schema documentation
```

## Getting Started

### Prerequisites
- .NET 8 SDK
- GraphQL server running on `http://localhost:5001/graphql` (configurable)

### Installation
1. Clone or download the project
2. Open the folder in Visual Studio Code
3. Restore packages: `dotnet restore`
4. Update the GraphQL endpoint in `appsettings.json` if needed
5. Run the application: `dotnet run`

### GraphQL Server Setup
The application requires a GraphQL server that implements the schema described in `GraphQL_Schema.md`. Key requirements:
- Endpoint: `http://localhost:5001/graphql` (default)
- Supports queries: `patient(id)` and `searchPatients(searchTerm)`
- Supports mutation: `savePatientData(input)`
- Handles CORS for the Blazor application

## Form Features

### Patient Demographics
- Patient ID (required)
- Patient Name (required)
- Date of Birth (required)
- Gender (required, dropdown)
- Phone Number

### Address Information
- Street Address
- City
- State (dropdown)
- ZIP Code

### Emergency Contact
- Emergency Contact Name
- Emergency Contact Phone

### Medical Information
- Primary Physician
- Admission Date
- Primary Diagnosis
- Current Medications (textarea)
- Known Allergies (textarea)

### Insurance Information
- Insurance Provider
- Policy Number

### Additional Information
- Priority Level (dropdown: Low, Normal, High, Critical)
- Patient Active Status (checkbox)
- Clinical Notes (large textarea)

### Form Actions
- **Search**: Find existing patients by ID or name
- **New Patient**: Clear form for new patient entry
- **Save**: Save patient data via GraphQL
- **Clear Form**: Reset all fields
- **Cancel**: Navigate back to home page

## Validation
The form includes comprehensive client-side validation:
- Required field validation
- Data type validation
- String length validation
- Real-time validation feedback

## Responsive Design
- Mobile-friendly interface
- Responsive grid layout
- Touch-friendly controls
- Optimized for various screen sizes

## Error Handling
- GraphQL operation error handling
- User-friendly error messages
- Loading states and feedback
- Network error resilience

## Conversion Notes
This Blazor form was converted from a WinForms ClinicalInputConsoleForm with the following improvements:
- Modern web-based interface
- Responsive design for multiple devices
- Real-time validation
- GraphQL integration for scalable data operations
- Reusable component architecture
- Better accessibility and user experience

## Development
To extend or modify the application:
1. Add new components in the `Components/` folder
2. Update the data model in `Models/ClinicalData.cs`
3. Modify the GraphQL service in `Services/ClinicalGraphQLService.cs`
4. Update styling in `wwwroot/css/clinical.css`
5. Add new pages in the `Pages/` folder

## Build and Deployment
- Build: `dotnet build`
- Run: `dotnet run`
- Publish: `dotnet publish -c Release`

The application follows Blazor Server best practices and is ready for production deployment.
