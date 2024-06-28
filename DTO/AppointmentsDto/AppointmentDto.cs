namespace HospitalManagementProject.DTO.AppointmentsDto;

public record class AppointmentDto(
    string Title,
    string Notes,
    DateTime AppointmentTime,
    Guid PatientId,
    Guid DoctorId
);