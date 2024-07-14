using HospitalManagementProject.DTO.InventoryDto;
using HospitalManagementProject.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementProject.Controllers
{
    public class InventoryController(IInventory inventoryRepo) : Controller
    {
        // GET: Inventory
        public async Task<IActionResult> Index()
        {
            var inventories = await inventoryRepo.GetAllAsync();
            return View(inventories);
        }

        // GET: Inventory/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var inventory = await inventoryRepo.GetByIdAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return View(inventory);
        }

        // GET: Inventory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateInventoryDto createInventoryDto)
        {
            if (!ModelState.IsValid) return View(createInventoryDto);
            var id = await inventoryRepo.AddAsync(createInventoryDto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Inventory/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var inventory = await inventoryRepo.GetByIdAsync(id);
            var editInventoryDto = new EditInventoryDto
            (Id :inventory.Id,
                ItemName:inventory.ItemName,
                Quantity : inventory.Quantity,
                ExpiryDate : inventory.ExpiryDate
            );
            return View(editInventoryDto);
        }

        // POST: Inventory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditInventoryDto editInventoryDto)
        {
            if (!ModelState.IsValid) return View(editInventoryDto);
            var updated = await inventoryRepo.UpdateAsync(editInventoryDto);
            if (!updated)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Inventory/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var inventory = await inventoryRepo.GetByIdAsync(id);
            return View(inventory);
        }

        // POST: Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var deleted = await inventoryRepo.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
