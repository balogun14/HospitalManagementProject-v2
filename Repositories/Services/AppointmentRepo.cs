using System.Globalization;
using HospitalManagementProject.Data;
using HospitalManagementProject.DTO.AppointmentsDto;
using HospitalManagementProject.Models.EHR;
using HospitalManagementProject.Repositories.Contracts;
using HospitalManagementProject.Worker_Services;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementProject.Repositories.Services;

public class AppointmentRepo(ApplicationDbContext context):IAppointment
{
    public async Task<IEnumerable<AppointmentDto>> GetAllAsync()
    {
        var appointment =  await context.Appointments.Include(appointment => appointment.Doctor)
            .Include(appointment => appointment.Patient).ToListAsync();
        var viewresult = appointment.Select(e => new AppointmentDto(
            Id:e.AppointmentId.ToString(),
            Title:e.Title,
            Notes:e.Notes!,
            AppointmentTime:e.AppointmentDate,
            Patient:e.Patient,
            Doctor:e.Doctor
        ));
        return viewresult;     }

    public async Task<AppointmentDto> GetByIdAsync(Guid id)
    {
        var isExistingAppointment = await context.Appointments.Include(appointment => appointment.Patient)
            .Include(appointment => appointment.Doctor).FirstOrDefaultAsync(e => e.AppointmentId == id);
        if (isExistingAppointment == null) return null;
        var appointment = new AppointmentDto(
            Id:isExistingAppointment.AppointmentId.ToString(),
            Title:isExistingAppointment.Title,
            Notes:isExistingAppointment.Notes!,
            AppointmentTime:isExistingAppointment.AppointmentDate,
            Patient:isExistingAppointment.Patient,
            Doctor:isExistingAppointment.Doctor
        );
        return appointment;
        
    }

    public async Task<Guid> AddAsync(CreateAppointmentDto createEntity)
    {
        var sendEmail = new SendEmailService();
        var patient = await context.Patients.FirstOrDefaultAsync(patient => createEntity.PatientId.ToLower() == patient.PatientId.ToString());
        var doctor = await context.Doctors.FirstOrDefaultAsync(d => createEntity.DoctorId.ToLower() == d.DoctorId.ToString());
        var appointment = new Appointment()
        {
            AppointmentId = Guid.NewGuid(),
            AppointmentDate = createEntity.AppointmentTime,
            Patient = patient!,
            Doctor = doctor!,
            Notes = createEntity.Notes,
            Title = createEntity.Title,
        };
        await context.Appointments.AddAsync(appointment);
        await context.SaveChangesAsync();
        SendEmailService.SendMail(appointment.Patient.Email, "Appointment Created Successfully", $"You have an appointment with {appointment.Doctor.FirstName} {appointment.Doctor.LastName} on {appointment.AppointmentDate.ToString(CultureInfo.InvariantCulture)} days");
        return appointment.AppointmentId;
    }

    public async Task<bool> UpdateAsync(EditAppointmentDto editEntity)
    {
        var rowAffected = await context.Appointments.Where(
            x => x.AppointmentId.ToString() == editEntity.Id).ExecuteUpdateAsync(s => s.SetProperty(e => e.AppointmentDate, editEntity.AppointmentTime).SetProperty(e=>e.Notes,editEntity.Notes).SetProperty(e=> e.Title,editEntity.Title));
        return rowAffected != 0;       }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var rowAffected = await context.Appointments.Where(e => e.AppointmentId == id).ExecuteDeleteAsync();
        return rowAffected != 0;      }
    
    public async Task<List<Appointment>> GetDueAppointmentsAsync(DateTime currentDate)
    {
        return await context.Appointments.Where(appointment => appointment.AppointmentDate < currentDate).ToListAsync();
    }
    
}