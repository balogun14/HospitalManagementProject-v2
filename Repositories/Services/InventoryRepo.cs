using HospitalManagementProject.Data;
using HospitalManagementProject.DTO.InventoryDto;
using HospitalManagementProject.Models.Inventory;
using HospitalManagementProject.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementProject.Repositories.Services;

public class InventoryRepo(ApplicationDbContext context):IInventory
{
    public async Task<IEnumerable<InventoryDto>> GetAllAsync()
    {
        var inventory =  await context.Inventories.ToListAsync();
        var viewresult = inventory.Select(e => new InventoryDto(
                Id:e.InventoryId,
                ItemName:e.ItemName,
                Quantity:e.Quantity,
                ExpiryDate:e.ExpiryDate
            ));
        return viewresult;
    }

    public async Task<InventoryDto> GetByIdAsync(Guid id)
    {
        var isExistingItem = await context.Inventories.FirstOrDefaultAsync(e => e.InventoryId == id);
        if (isExistingItem == null) return null;
        var dto = new InventoryDto(
            Id: isExistingItem.InventoryId,
            ItemName: isExistingItem.ItemName,
            Quantity: isExistingItem.Quantity,
            ExpiryDate: isExistingItem.ExpiryDate
        );
        return dto;

    }

    public async Task<Guid> AddAsync(CreateInventoryDto createEntity)
    {
        var item = new Inventory()
        {
            Quantity = createEntity.Quantity,
            ExpiryDate = createEntity.ExpiryDate,
            InventoryId = Guid.NewGuid(),
            ItemName = createEntity.ItemName
        };
        await context.Inventories.AddAsync(item);
        await context.SaveChangesAsync();
        return item.InventoryId;
    }

    public async Task<bool> UpdateAsync(EditInventoryDto editEntity)
    {
        var rowAffected = await context.Inventories.Where(
            x => x.InventoryId == editEntity.Id).ExecuteUpdateAsync(s => s.SetProperty(e => e.ExpiryDate, editEntity.ExpiryDate).SetProperty(e=>e.Quantity,editEntity.Quantity).SetProperty(e=> e.ItemName,editEntity.ItemName));
        return rowAffected != 0;    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var rowAffected = await context.Inventories.Where(e => e.InventoryId == id).ExecuteDeleteAsync();
        return rowAffected != 0;     }
}