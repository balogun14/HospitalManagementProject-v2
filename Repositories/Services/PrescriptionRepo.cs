using HospitalManagementProject.Data;
using HospitalManagementProject.DTO.PrescriptionDto;
using HospitalManagementProject.Models.EHR;
using HospitalManagementProject.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementProject.Repositories.Services;

public class PrescriptionRepo(ApplicationDbContext context):IPrescription
{
    public async Task<IEnumerable<PrescriptionDto>> GetAllAsync()
    {
        var prescription =  await context.Prescriptions.Include(prescription => prescription.Doctor)
            .Include(prescription => prescription.Patient).ToListAsync();
        var viewresult = prescription.Select(e => new PrescriptionDto(
            Id:e.PrescriptionId,
            Symptoms: e.Symptoms,
            Diagnosis:e.Diagnosis,
            Medications:e.Medication,
            Treatment:e.Treatment,
            DateIssued:e.DateIssued,
            Doctor:e.Doctor,
            Patient:e.Patient
        ));
        return viewresult;      
    }

    public async Task<PrescriptionDto> GetByIdAsync(Guid id)
    {
        var isExistingPrescription = await context.Prescriptions.Include(prescription => prescription.Doctor)
            .Include(prescription => prescription.Patient).FirstOrDefaultAsync(e => e.PrescriptionId == id);
        if (isExistingPrescription == null) return null;
        var prescription = new PrescriptionDto(
            Id:isExistingPrescription.PrescriptionId,
            Symptoms: isExistingPrescription.Symptoms,
            Diagnosis:isExistingPrescription.Diagnosis,
            Medications:isExistingPrescription.Medication,
            Treatment:isExistingPrescription.Treatment,
            DateIssued:isExistingPrescription.DateIssued,
            Doctor:isExistingPrescription.Doctor,
            Patient:isExistingPrescription.Patient
        );
        return prescription;    }

    public async Task AddAsync(CreatePrescriptionDto createEntity)
    {
        var prescription = new Prescription()
        {
            PrescriptionId = Guid.NewGuid(),
            Symptoms = createEntity.Symptoms,
            Diagnosis= createEntity.Diagnosis,
            Medication =createEntity.Medications,
            Treatment=createEntity.Treatment,
            DoctorId= createEntity.Doctor,
            PatientId= createEntity.Patient,
            DateIssued = DateTime.Now
        };
        await context.Prescriptions.AddAsync(prescription);
        await context.SaveChangesAsync();
        
    }

    public async Task<bool> UpdateAsync(EditPrescriptionDto editEntity)
    {
        var rowAffected = await context.Prescriptions.Where(
            x => x.PrescriptionId == editEntity.Id).ExecuteUpdateAsync(s => s.SetProperty(e => e.Symptoms, editEntity.Symptoms).SetProperty(e => e.Diagnosis, editEntity.Diagnosis).SetProperty(e => e.Medication, editEntity.Medications).SetProperty(e=>e.Treatment,editEntity.Treatment).SetProperty(e=>e.DoctorId,editEntity.Doctor).SetProperty(e=>e.PatientId,editEntity.Patient));
        return rowAffected != 0;       }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var rowAffected = await context.Prescriptions.Where(e => e.PrescriptionId == id).ExecuteDeleteAsync();
        return rowAffected != 0;     
    }
}