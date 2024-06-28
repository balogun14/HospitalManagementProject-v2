using HospitalManagementProject.DTO.AppointmentsDto;
using HospitalManagementProject.Repositories.Contracts;

namespace HospitalManagementProject.Repositories.Services;

public class AppointmentRepo:IAppointment
{
    public async Task<IEnumerable<AppointmentDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<AppointmentDto> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(CreateAppointmentDto createEntity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(EditAppointmentDto editEntity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}