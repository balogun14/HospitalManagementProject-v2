namespace HospitalManagementProject.DTO.AppointmentsDto;

public record class CreateAppointmentDto(
    string Title,
    string Notes,
    DateTime AppointmentTime,
    string PatientId,
    string DoctorId
    );