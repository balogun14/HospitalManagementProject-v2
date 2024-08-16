using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HospitalManagementProject.Enums;

namespace HospitalManagementProject.DTO.DoctorsDto;

public record class EditDoctorDto(
    Guid Id,
    [Required(ErrorMessage ="First Name was not supplied")]
    [property: DisplayName("First Name")]
    string Firstname,
    [Required(ErrorMessage ="Last Name was not supplied")]
    [property: DisplayName("Last Name")]
    string LastName,
    Specialization Speciality,
    [Required(ErrorMessage ="Phone number was not supplied")]
    [property: DisplayName("Phone Number")]
    string PhoneNumber

    );