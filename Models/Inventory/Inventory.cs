namespace HospitalManagementProject.Models.Inventory;

public class Inventory
{
    public Guid InventoryId { get; set; }
    public string ItemName { get; set; }
    public int Quantity { get; set; }
    public DateTime ExpiryDate { get; set; }
}
