using HospitalManagementProject.Enums;

namespace HospitalManagementProject.DTO.DoctorsDto;

public record class EditDoctorDto(
    Guid Id,
    string Firstname,
    string LastName,
    Specialization Speciality,
 string PhoneNumber

    );