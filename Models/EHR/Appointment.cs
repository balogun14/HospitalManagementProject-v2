using System.ComponentModel.DataAnnotations;

namespace HospitalManagementProject.Models.EHR;

public class Appointment
{
    public Guid AppointmentId { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    [StringLength(200)]
    public string Title { get; set; }
    public DateTime AppointmentDate { get; set; }
    [StringLength(500)]
    public string? Notes { get; set; }
}
