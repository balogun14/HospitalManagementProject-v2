namespace HospitalManagementProject.DTO.InventoryDto;

public record CreateInventoryDto(
 string ItemName,
 int Quantity,
 DateTime ExpiryDate 
    );