using System.ComponentModel.DataAnnotations;

namespace BackOffice.Blazor.Models
{
    public class ClinicalInputData
    {
        [Required]
        [StringLength(50)]
        public string PatientId { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string PatientName { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; } = string.Empty;

        [StringLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        [StringLength(200)]
        public string Address { get; set; } = string.Empty;

        [StringLength(50)]
        public string City { get; set; } = string.Empty;

        [StringLength(10)]
        public string State { get; set; } = string.Empty;

        [StringLength(10)]
        public string ZipCode { get; set; } = string.Empty;

        [StringLength(100)]
        public string EmergencyContact { get; set; } = string.Empty;

        [StringLength(20)]
        public string EmergencyPhone { get; set; } = string.Empty;

        [StringLength(100)]
        public string PrimaryPhysician { get; set; } = string.Empty;

        [StringLength(200)]
        public string Diagnosis { get; set; } = string.Empty;

        [StringLength(500)]
        public string Medications { get; set; } = string.Empty;

        [StringLength(500)]
        public string Allergies { get; set; } = string.Empty;

        [StringLength(1000)]
        public string Notes { get; set; } = string.Empty;

        public DateTime AdmissionDate { get; set; } = DateTime.Today;

        [StringLength(50)]
        public string InsuranceProvider { get; set; } = string.Empty;

        [StringLength(50)]
        public string InsurancePolicyNumber { get; set; } = string.Empty;

        [StringLength(20)]
        public string Priority { get; set; } = "Normal";

        public bool IsActive { get; set; } = true;
    }

    public class ClinicalInputResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string PatientId { get; set; } = string.Empty;
    }
}
