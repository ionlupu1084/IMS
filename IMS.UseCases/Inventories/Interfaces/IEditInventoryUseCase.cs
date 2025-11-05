using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.Inventories.Interfaces
{
    public interface IEditInventoryUseCase
    {
        IInventoryRepository InventoryRepository { get; }
        Task ExecuteAsync(Inventory inventory);

    }
}
