using HospitalManagementProject.Models.EHR;

namespace HospitalManagementProject.DTO.PrescriptionDto;

public record class PrescriptionDto(
    Guid Id,
    string Symptoms,
    string Diagnosis,
    string Medications,
    string Treatment,
    DateTime DateIssued,
    Doctor Doctor,
    Patient Patient
);