using System.ComponentModel.DataAnnotations;
using HospitalManagementProject.Enums;

namespace HospitalManagementProject.Models.EHR;

public class Doctor
{
    public Guid DoctorId { get; set; }
    [StringLength(100)]

    public required string FirstName { get; set; }
    [StringLength(100)]

    public required string LastName { get; set; }
    public Specialization Specialty { get; set; }
    [StringLength(13)]
    public string PhoneNumber { get; set; }
    
    public ICollection<Appointment>? Appointments { get; set; }
}
