using System.ComponentModel.DataAnnotations;
using HospitalManagementProject.Enums;

namespace HospitalManagementProject.DTO.PatientsDto;

public record class EditPatientDto(
    Guid Id,
    string GivenName,
    string FamilyName,
    DateTime Dob,
    Gender Sex,
    BloodGroups BloodGroups,
    MaritalStatus MaritalStatus,
    [Required(ErrorMessage = "Email is required")] 
    [EmailAddress]
    string Email,
    string? Address,
    [StringLength(13)] string PhoneNumber
    );