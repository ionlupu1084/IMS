using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IInventoryRepository
    {
        Task AddInventoryAsync(Inventory inventory);
        Task DeleteInventoryAsync(Inventory inventory);
        Task DeleteInventoryByIdAsync(int inventoryID);
        Task<Inventory> GetInventoryByIDAsync(int inventoryID);
        Task<IEnumerable<Inventory>> GetInventoryByNameAsync(string name);
        Task UpdateInventoryAsync(Inventory inventory);
    }
}
