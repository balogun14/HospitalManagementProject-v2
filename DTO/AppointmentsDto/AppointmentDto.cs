using System.ComponentModel;
using HospitalManagementProject.Models.EHR;

namespace HospitalManagementProject.DTO.AppointmentsDto;

public record class AppointmentDto(
    string Id,
    string Title,
    string Notes,
    [property: DisplayName("Time of Appointment")]
    DateTime AppointmentTime,
    Patient Patient,
    Doctor Doctor
);