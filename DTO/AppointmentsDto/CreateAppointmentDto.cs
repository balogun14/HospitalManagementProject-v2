using System.ComponentModel;

namespace HospitalManagementProject.DTO.AppointmentsDto;

public record class CreateAppointmentDto(
    string Title,
    string Notes,
    [property: DisplayName("Time of Appointment")]

    DateTime AppointmentTime,
    [property: DisplayName("Patient Name")]

    string PatientId,
    [property: DisplayName("Doctor Name")]

    string DoctorId
    );