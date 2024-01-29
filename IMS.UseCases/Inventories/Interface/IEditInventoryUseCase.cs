using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories.Interface
{
    public interface IEditInventoryUseCase
    {
        Task ExecuteAsync(Inventory inventory);
    }
}