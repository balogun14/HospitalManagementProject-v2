using HospitalManagementProject.Data;
using HospitalManagementProject.DTO.DoctorsDto;
using HospitalManagementProject.Models.EHR;
using HospitalManagementProject.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementProject.Repositories.Services;

public class DoctorRepo(ApplicationDbContext context,ILogger<DoctorRepo> logger):IDoctor
{
    private readonly ILogger<DoctorRepo> _logger = logger;

    public async Task<IEnumerable<DoctorDto>> GetAllAsync()
    {
        var doctor =  await context.Doctors.Include(doctor => doctor.Appointments).ToListAsync();
        var viewresult = doctor.Select(e => new DoctorDto(
            Id:e.DoctorId,
            Firstname:e.FirstName,
            LastName:e.LastName,
            Speciality:e.Specialty,
            PhoneNumber:e.PhoneNumber,
            Appointments:e.Appointments
        ));
        return viewresult;    }

    public async Task<DoctorDto> GetByIdAsync(Guid id)
    {
        var isExistingDoctor = await context.Doctors.Include(doctor => doctor.Appointments).FirstOrDefaultAsync(e => e.DoctorId == id);
        if (isExistingDoctor == null) return null;
        var doctor = new DoctorDto(
            Id:isExistingDoctor.DoctorId,
            Firstname:isExistingDoctor.FirstName,
            LastName:isExistingDoctor.LastName,
            Speciality:isExistingDoctor.Specialty,
            PhoneNumber:isExistingDoctor.PhoneNumber,
            Appointments:isExistingDoctor.Appointments
        );
        return doctor;        }

    public async Task<Guid> AddAsync(CreateDoctorDto createEntity)
    {
        var doctor = new Doctor()
        {
            DoctorId = Guid.NewGuid(),
            FirstName = createEntity.Firstname,
            LastName = createEntity.LastName,
            PhoneNumber = createEntity.PhoneNumber,
            Specialty = createEntity.Speciality
        };
        await context.Doctors.AddAsync(doctor);
        await context.SaveChangesAsync();
        return doctor.DoctorId;
    }

    public async Task<bool> UpdateAsync(EditDoctorDto editEntity)
    {
        var rowAffected = await context.Doctors.Where(
            x => x.DoctorId == editEntity.Id).ExecuteUpdateAsync(s => s.SetProperty(e => e.FirstName, editEntity.Firstname).SetProperty(e => e.LastName, editEntity.LastName).SetProperty(e => e.Specialty, editEntity.Speciality).SetProperty(e=>e.PhoneNumber,editEntity.PhoneNumber));
        return rowAffected != 0;    
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var rowAffected = await context.Doctors.Where(e => e.DoctorId == id).ExecuteDeleteAsync();
        return rowAffected != 0;     
    }
}