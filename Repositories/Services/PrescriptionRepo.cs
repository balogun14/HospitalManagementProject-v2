using HospitalManagementProject.DTO.PrescriptionDto;
using HospitalManagementProject.Repositories.Contracts;

namespace HospitalManagementProject.Repositories.Services;

public class PrescriptionRepo:IPrescription
{
    public async Task<IEnumerable<PrescriptionDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<PrescriptionDto> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(CreatePrescriptionDto createEntity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(EditPrescriptionDto editEntity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}