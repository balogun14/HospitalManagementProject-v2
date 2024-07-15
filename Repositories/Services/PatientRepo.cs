using HospitalManagementProject.Data;
using HospitalManagementProject.DTO.PatientsDto;
using HospitalManagementProject.Models.EHR;
using HospitalManagementProject.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementProject.Repositories.Services;

public class PatientRepo(ApplicationDbContext context,ILogger<PatientRepo> logger) : IPatient
{
    private readonly ILogger<PatientRepo> _logger = logger;


    public async Task<IEnumerable<PatientDto>> GetAllAsync()
    {
        var patient =  await context.Patients.Include(patient => patient.Appointments)
            .Include(patient => patient.Prescriptions).ToListAsync();
        var viewresult = patient.Select(e => new PatientDto(
            Id:e.PatientId,
            GivenName:e.FirstName!,
            FamilyName:e.LastName!,
            Dob:e.DateOfBirth,
            Sex:e.Gender,
            BloodGroups:e.BloodGroups,
            MaritalStatus:e.MaritalStatus,
            Address:e.Address,
            PhoneNumber:e.PhoneNumber,
            Prescriptions:e.Prescriptions,
            Appointments:e.Appointments,
            Email:e.Email
            ));
        return viewresult;
    }

    public async Task<PatientDto> GetByIdAsync(Guid id)
    {
        var isExistingPatient = await context.Patients.Include(patient => patient.Prescriptions)
            .Include(patient => patient.Appointments).FirstOrDefaultAsync(e => e.PatientId == id);
        if (isExistingPatient == null) return null;
        var patient = new PatientDto(
            Id:isExistingPatient.PatientId,
            GivenName:isExistingPatient.FirstName!,
            FamilyName:isExistingPatient.LastName!,
            Dob:isExistingPatient.DateOfBirth,
            Sex:isExistingPatient.Gender,
            BloodGroups:isExistingPatient.BloodGroups,
            MaritalStatus:isExistingPatient.MaritalStatus,
            Address:isExistingPatient.Address,
            PhoneNumber:isExistingPatient.PhoneNumber,
            Prescriptions:isExistingPatient.Prescriptions,
            Appointments:isExistingPatient.Appointments  ,
            Email:isExistingPatient.Email
            );
        return patient;     }

    public async Task<Guid> AddAsync(CreatePatientDto createEntity)
    {
        var patient = new Patient()
        {
            PatientId = Guid.NewGuid(),
            FirstName = createEntity.GivenName,
            LastName = createEntity.FamilyName,
            PhoneNumber = createEntity.PhoneNumber,
            Gender = createEntity.Sex,
            BloodGroups = createEntity.BloodGroups,
            MaritalStatus = createEntity.MaritalStatus,
            Address = createEntity.Address,
            DateOfBirth = createEntity.Dob,
            Email = createEntity.Email
        };
        await context.Patients.AddAsync(patient);
        await context.SaveChangesAsync();
        return patient.PatientId;
    }

    public async Task<bool> UpdateAsync(EditPatientDto editEntity)
    {
        var rowAffected = await context.Patients.Where(
            x => x.PatientId == editEntity.Id).ExecuteUpdateAsync(s => s.SetProperty(e => e.FirstName, editEntity.GivenName).SetProperty(e => e.LastName, editEntity.FamilyName).SetProperty(e => e.Address, editEntity.Address).SetProperty(e=>e.MaritalStatus,editEntity.MaritalStatus).SetProperty(e=>e.Gender,editEntity.Sex).SetProperty(e=>e.Email,editEntity.Email));
        return rowAffected != 0;
        
    }

    
    public async Task<bool> DeleteAsync(Guid id)
    {
        var rowAffected = await context.Patients.Where(e => e.PatientId == id).ExecuteDeleteAsync();
        return rowAffected != 0;     
    }
}