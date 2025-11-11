using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Plugins.InMemory
{
    public class InventoryTransactionRepository : IInventoryTransactionRepository
    {
        public List<InventoryTransaction> _inventoryTransactions = new List<InventoryTransaction>();
        public void PurchaseaAsync(string poNumber, Inventory inventory, int quantity, string doneBy, double price)
        {
            this._inventoryTransactions.Add(new InventoryTransaction
            {
                PONumber = poNumber,
                InventoryId = inventory.InventoryID,
                QuantityBefore = quantity,
                ActivityType = InventoryTransactionType.PurchaseInventory,
                QuantityAfter = inventory.Quantity+quantity,
                TransactionDate= DateTime.Now,
                DoneBy = doneBy
                
            });
        }
    }
}
