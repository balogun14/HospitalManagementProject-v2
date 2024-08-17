using System.ComponentModel;

namespace HospitalManagementProject.DTO.PrescriptionDto;

public record class CreatePrescriptionDto(
    string Symptoms,
    string Diagnosis,
    string Medications,
    string Treatment,
    [property: DisplayName("Doctor")]
    Guid DoctorId,
    [property: DisplayName("Patient")]
    Guid PatientId
    );