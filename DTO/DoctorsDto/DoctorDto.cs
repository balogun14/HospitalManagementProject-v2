using System.ComponentModel;
using HospitalManagementProject.Enums;
using HospitalManagementProject.Models.EHR;

namespace HospitalManagementProject.DTO.DoctorsDto;

public record class DoctorDto(
    Guid Id,
    [property: DisplayName("First Name")]
    string Firstname,
    [property: DisplayName("Last Name")]
    string LastName,
    Specialization Speciality,
    [property: DisplayName("Phone Number")]
    string PhoneNumber,
    ICollection<Appointment>? Appointments

    );
