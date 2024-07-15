using HospitalManagementProject.Enums;

namespace HospitalManagementProject.Models.EHR;

public class Patient
{
    public Guid PatientId { get; set; }
    public  string FirstName { get; set; }
    public  string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Address { get; set; }
    public  string PhoneNumber { get; set; }
    public Gender Gender { get; set; }
    public BloodGroups BloodGroups { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public required string Email { get; set; }
    public ICollection<Prescription>? Prescriptions { get; set; }
    public ICollection<Appointment>? Appointments { get; set; }
}
