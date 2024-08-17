using System.ComponentModel;

namespace HospitalManagementProject.DTO.AppointmentsDto;

public record class EditAppointmentDto(
    string Id,
    string Title,
    string Notes,
    [property: DisplayName("Time of Appointment")]
    DateTime AppointmentTime,
    [property: DisplayName("Patient Name")]

    Guid PatientId,
    [property: DisplayName("Doctor Name")]
    Guid DoctorId
    
    );