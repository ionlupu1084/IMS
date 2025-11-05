using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace IMS.UseCases.Inventories
{
    public class ViewInventoryByIDUseCase : IViewInventoryByIDUseCase
    {
        private readonly IInventoryRepository inventoryRepository;

        public ViewInventoryByIDUseCase(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }
        public async Task<Inventory> ExecuteAsync(int inventoryID = 1)
        {
            return await this.inventoryRepository.GetInventoryByIDAsync(inventoryID);
        }
    }
}
