using HospitalManagementProject.Enums;

namespace HospitalManagementProject.DTO.DoctorsDto;

public record class DoctorDto(
    string Firstname,
    string LastName,
    Specialization Speciality,
    string PhoneNumber

    );
