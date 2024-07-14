using HospitalManagementProject.DTO.InventoryDto;
using HospitalManagementProject.Repositories.Contracts;

namespace HospitalManagementProject.Repositories.Services;

public class InventoryRepo:IInventory
{
    public async Task<IEnumerable<InventoryDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<InventoryDto> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> AddAsync(CreateInventoryDto createEntity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(EditInventoryDto editEntity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}