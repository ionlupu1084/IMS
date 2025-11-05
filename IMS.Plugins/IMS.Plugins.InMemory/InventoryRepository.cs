using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories;
        public InventoryRepository() { 
        
        _inventories=new List<Inventory>()
        {
            new Inventory { InventoryID=1, InventoryName="Byke Seat", Quantity=10, Price=2},
            new Inventory { InventoryID=2, InventoryName="Byke Body", Quantity=10, Price=15},
            new Inventory { InventoryID=3, InventoryName="Byke Wheels" , Quantity=20 , Price=8},
            new Inventory { InventoryID=3, InventoryName="Byke Pedals", Quantity=20 , Price=1}
        };

        }

        public Task AddInventoryAsync(Inventory inventory)
        {
            if (_inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }
            var maxID = _inventories.Max(x => x.InventoryID);
            inventory.InventoryID = maxID + 1;

            _inventories.Add(inventory);
            return Task.CompletedTask;

        }

        public async Task<Inventory> GetInventoryByIDAsync(int inventoryID)
        {
            return await Task.FromResult(_inventories.First(x  => x.InventoryID == inventoryID));
        }

        public async Task<IEnumerable<Inventory>> GetInventoryByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories);
            return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public Task UpdateInventoryAsync(Inventory inventory)
        {
            if (_inventories.Any(x =>x.InventoryID!= inventory.InventoryID &&
            x.InventoryName.Equals(inventory.InventoryName,StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }
            var invToUpdate=_inventories.FirstOrDefault(x=> x.InventoryID == inventory.InventoryID);
            if (invToUpdate != null)
            {
                invToUpdate.InventoryName = inventory.InventoryName;
                invToUpdate.Quantity = inventory.Quantity;
                invToUpdate.Price = inventory.Price;
            }
            return Task.CompletedTask;
        }
    }
}
