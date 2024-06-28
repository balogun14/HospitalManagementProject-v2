namespace HospitalManagementProject.DTO.AppointmentsDto;

public record class CreateAppointmentDto(
    string Title,
    string Notes,
    DateTime AppointmentTime,
    Guid PatientId,
    Guid DoctorId
    );