namespace HospitalManagementProject.Models.EHR;

public class Appointment
{
    public Guid AppointmentId { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public string Title { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string? Notes { get; set; }
}
