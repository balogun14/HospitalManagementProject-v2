namespace HospitalManagementProject.Models.EHR;

public class Prescription
{
    public Guid PrescriptionId { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public string Medication { get; set; }
    public string Dosage { get; set; }
    public string Diagnosis { get; set; }
    public string Symptoms { get; set; }
    public DateTime DateIssued { get; set; }
}
