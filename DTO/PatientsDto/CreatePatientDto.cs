using System.ComponentModel.DataAnnotations;
using HospitalManagementProject.Enums;

namespace HospitalManagementProject.DTO.PatientsDto;

public record class CreatePatientDto(
    [Required(ErrorMessage = "First Name is required")]
    [Display(Name = "First Name")]
    string GivenName,
    [Required(ErrorMessage = "Last Name is required")]
    [Display(Name = "Last Name")]
    string FamilyName,
    [Required(ErrorMessage = "Dob is required")]
    [Display(Name = "Date Of Birth")]
    DateTime Dob,
    [Required(ErrorMessage = "Address Name is required")]
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