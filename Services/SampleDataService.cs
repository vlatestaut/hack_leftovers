using BackOffice.Blazor.Models;

namespace BackOffice.Blazor.Services
{
    public class SampleDataService
    {
        public static List<ClinicalInputData> GetSamplePatients()
        {
            return new List<ClinicalInputData>
            {
                new ClinicalInputData
                {
                    PatientId = "MR001",
                    PatientName = "John Smith",
                    DateOfBirth = new DateTime(1965, 3, 15),
                    Gender = "Male",
                    PhoneNumber = "(555) 123-4567",
                    Address = "123 Main St",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = "75201",
                    PrimaryPhysician = "Dr. Johnson",
                    Diagnosis = "Cardiology - Hypertension",
                    Priority = "High",
                    InsuranceProvider = "Blue Cross",
                    InsurancePolicyNumber = "BC123456",
                    IsActive = true,
                    Notes = "Patient requires regular monitoring"
                },
                new ClinicalInputData
                {
                    PatientId = "MR002",
                    PatientName = "Mary Davis",
                    DateOfBirth = new DateTime(1972, 8, 22),
                    Gender = "Female",
                    PhoneNumber = "(555) 234-5678",
                    Address = "456 Oak Ave",
                    City = "Houston",
                    State = "TX",
                    ZipCode = "77001",
                    PrimaryPhysician = "Dr. Williams",
                    Diagnosis = "Neurology - Migraine",
                    Priority = "Medium",
                    InsuranceProvider = "Aetna",
                    InsurancePolicyNumber = "AE789012",
                    IsActive = true,
                    Notes = "Follow-up in 3 months"
                },
                new ClinicalInputData
                {
                    PatientId = "MR003",
                    PatientName = "Robert Wilson",
                    DateOfBirth = new DateTime(1958, 12, 5),
                    Gender = "Male",
                    PhoneNumber = "(555) 345-6789",
                    Address = "789 Pine Rd",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "73301",
                    PrimaryPhysician = "Dr. Brown",
                    Diagnosis = "Orthopedics - Knee Replacement",
                    Priority = "Critical",
                    InsuranceProvider = "Medicare",
                    InsurancePolicyNumber = "MC345678",
                    IsActive = true,
                    Notes = "Post-surgical care required"
                },
                new ClinicalInputData
                {
                    PatientId = "MR004",
                    PatientName = "Jennifer Lee",
                    DateOfBirth = new DateTime(1980, 5, 10),
                    Gender = "Female",
                    PhoneNumber = "(555) 456-7890",
                    Address = "321 Elm St",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = "78201",
                    PrimaryPhysician = "Dr. Garcia",
                    Diagnosis = "General Medicine - Annual Checkup",
                    Priority = "Low",
                    InsuranceProvider = "Cigna",
                    InsurancePolicyNumber = "CG901234",
                    IsActive = true,
                    Notes = ""
                },
                new ClinicalInputData
                {
                    PatientId = "MR005",
                    PatientName = "Michael Thompson",
                    DateOfBirth = new DateTime(1945, 9, 18),
                    Gender = "Male",
                    PhoneNumber = "(555) 567-8901",
                    Address = "654 Maple Dr",
                    City = "Fort Worth",
                    State = "TX",
                    ZipCode = "76101",
                    PrimaryPhysician = "Dr. Martinez",
                    Diagnosis = "Cardiology - Heart Disease",
                    Priority = "High",
                    InsuranceProvider = "United Healthcare",
                    InsurancePolicyNumber = "UH567890",
                    IsActive = false,
                    Notes = "Discharged - follow-up with cardiologist"
                }
            };
        }
    }
}
