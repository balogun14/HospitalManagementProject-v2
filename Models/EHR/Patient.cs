using System.ComponentModel.DataAnnotations;
using HospitalManagementProject.Enums;

namespace HospitalManagementProject.Models.EHR;

public class Patient
{
    public Guid PatientId { get; set; }
    [StringLength(100)]

    public  string FirstName { get; set; }
    [StringLength(100)]

    public  string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    [StringLength(100)]

    public string? Address { get; set; }
    [StringLength(13)]

    public  string PhoneNumber { get; set; }
    public Gender Gender { get; set; }
    public BloodGroups BloodGroups { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    [StringLength(30)]
    [EmailAddress]
    public required string Email { get; set; }
    public ICollection<Prescription>? Prescriptions { get; set; }
    public ICollection<Appointment>? Appointments { get; set; }
}
