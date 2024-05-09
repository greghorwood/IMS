using IMS.CoreBusiness;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IProductTransactionRepository
    {
        Task ProduceAsync(string productionNumber, Product product, int quantity, string doneby);
        public Task ProduceAsync(string productionNumber, Product product, int quantity, double price, string doneby);
    }
}