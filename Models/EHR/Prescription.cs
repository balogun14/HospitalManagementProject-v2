using System.ComponentModel.DataAnnotations;

namespace HospitalManagementProject.Models.EHR;

public class Prescription
{
    public Guid PrescriptionId { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; } 
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    [StringLength(500)]
    public string Medication { get; set; } 
    [StringLength(500)]

    public string Diagnosis { get; set; }
    [StringLength(500)]

    public string Symptoms { get; set; }
    [StringLength(500)]

    public string Treatment { get; set; }
    
    public DateTime DateIssued { get; set; }
}
