using HospitalManagementProject.Enums;

namespace HospitalManagementProject.DTO.DoctorsDto;

public record class CreateDoctorDto(
    string Firstname,
    string LastName,
    Specialization Speciality,
    string PhoneNumber
    );