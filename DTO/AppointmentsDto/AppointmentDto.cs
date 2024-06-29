using HospitalManagementProject.Models.EHR;

namespace HospitalManagementProject.DTO.AppointmentsDto;

public record class AppointmentDto(
    Guid Id,
    string Title,
    string Notes,
    DateTime AppointmentTime,
    Patient Patient,
    Doctor Doctor
);