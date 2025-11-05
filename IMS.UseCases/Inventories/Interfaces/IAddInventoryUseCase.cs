using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories.Interfaces
{
    public interface IAddInventoryUseCase
    {
        IInventoryRepository InventoryRepository { get; }

        Task ExecuteAsync(Inventory inventory);
    }
}