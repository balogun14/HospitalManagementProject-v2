using HospitalManagementProject.DTO.DoctorsDto;
using HospitalManagementProject.Repositories.Contracts;

namespace HospitalManagementProject.Repositories.Services;

public class DoctorRepo:IDoctor
{
    public Task<IEnumerable<DoctorDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<DoctorDto> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(CreateDoctorDto createEntity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(EditDoctorDto editEntity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}