using HospitalManagementProject.Models.EHR;

namespace HospitalManagementProject.DTO.PrescriptionDto;

public record class CreatePrescriptionDto(
    string Symptoms,
    string Diagnosis,
    string Medications,
    string Treatment,
    Guid Doctor,
    Guid Patient
    );