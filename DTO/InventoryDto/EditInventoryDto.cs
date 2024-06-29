namespace HospitalManagementProject.DTO.InventoryDto;

public record EditInventoryDto(
    Guid Id,
    string ItemName,
    int Quantity,
    DateTime ExpiryDate
    );