using HospitalManagementProject.DTO.AppointmentsDto;

namespace HospitalManagementProject.Repositories.Contracts;

public interface IAppointment:IBaseRepo<AppointmentDto,CreateAppointmentDto,EditAppointmentDto>
{
}