namespace HospitalManagementProject.DTO.InventoryDto;

public record InventoryDto(
    Guid Id,
    string ItemName,
    int Quantity,
    DateTime ExpiryDate );