using System.ComponentModel.DataAnnotations;
using HospitalManagementProject.Enums;
using HospitalManagementProject.Models.EHR;

namespace HospitalManagementProject.DTO.PatientsDto;

public record class PatientDto(
    Guid Id,
    [Required(ErrorMessage = "First Name is required")]
    string GivenName,
    [Required(ErrorMessage = "First Name is required")]
    string FamilyName,
    [Required(ErrorMessage = "First Name is required")]
    DateTime Dob,
    string? Address,
    [StringLength(13)] 
    string PhoneNumber,
    Gender Sex,
    [Required(ErrorMessage = "Email is required")] 
    [EmailAddress]
    string Email,
    BloodGroups BloodGroups,
    MaritalStatus MaritalStatus,
    ICollection<Prescription>? Prescriptions,
ICollection<Appointment>? Appointments
);