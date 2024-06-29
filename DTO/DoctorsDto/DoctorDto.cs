using HospitalManagementProject.Enums;
using HospitalManagementProject.Models.EHR;

namespace HospitalManagementProject.DTO.DoctorsDto;

public record class DoctorDto(
    Guid Id,
    string Firstname,
    string LastName,
    Specialization Speciality,
    string PhoneNumber,
    ICollection<Appointment>? Appointments

    );
