using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.Inventories
{
    public class DeleteInventoryUseCase : IDeleteInventoryUseCase
    {
        private readonly IInventoryRepository inventoryRepository;
        public DeleteInventoryUseCase(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }
        public IInventoryRepository InventoryRepository { get; }
        public async Task ExecuteAsync(Inventory inventory)
        {
            await this.inventoryRepository.DeleteInventoryAsync(inventory);
        }
    }
}
