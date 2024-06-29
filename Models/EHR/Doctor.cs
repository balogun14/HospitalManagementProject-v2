using HospitalManagementProject.Enums;

namespace HospitalManagementProject.Models.EHR;

public class Doctor
{
    public Guid DoctorId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public Specialization Specialty { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<Appointment>? Appointments { get; set; }
}
