using System.ComponentModel.DataAnnotations;
using HospitalManagementProject.Enums;

namespace HospitalManagementProject.DTO.DoctorsDto;

public record class EditDoctorDto(
    Guid Id,
    [Required(ErrorMessage ="First Name was not supplied")]
    string Firstname,
    [Required(ErrorMessage ="Last Name was not supplied")]
    string LastName,
    Specialization Speciality,
    [Required(ErrorMessage ="Phone number was not supplied")]
    string PhoneNumber

    );