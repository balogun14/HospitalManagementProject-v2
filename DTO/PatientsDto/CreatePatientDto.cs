using System.ComponentModel.DataAnnotations;
using HospitalManagementProject.Enums;

namespace HospitalManagementProject.DTO.PatientsDto;

public record class CreatePatientDto(
    [Required(ErrorMessage = "First Name is required")]
    string GivenName,
    [Required(ErrorMessage = "Last Name is required")]
    string FamilyName,
    [Required(ErrorMessage = "Dob is required")]
    DateTime Dob,
    [Required(ErrorMessage = "Adress Name is required")]
    string Address,
    [StringLength(13)] 
    string PhoneNumber,
    [Required(ErrorMessage = "Gender Name is required")] 
    Gender Sex,
    [Required(ErrorMessage = "Email is required")] 
    [EmailAddress]
    string Email,
    [Required(ErrorMessage = "Blood Name is required")]

    BloodGroups BloodGroups,
    [Required(ErrorMessage = "Marital Name is required")]
    MaritalStatus MaritalStatus
    );