using IMS.CoreBusiness;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IInventoryTransactionRepository
    {
        void PurchaseaAsync(string poNumber, Inventory inventory, int quantity, string doneBy, double price);
    }
}