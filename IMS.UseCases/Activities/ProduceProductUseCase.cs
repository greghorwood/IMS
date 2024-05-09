using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Activities
{
    public class ProduceProductUseCase
    {
        private readonly IProductTransactionRepository productTransactionRepository;
        private readonly IProductRepository productRepository;

        public ProduceProductUseCase(IProductTransactionRepository productTransactionRepository,
            IProductRepository productRepository)
        {
            this.productTransactionRepository = productTransactionRepository;
            this.productRepository = productRepository;
        }
        public async Task ExecuteAsync(string productionNumber, Product product, int quantity, string doneby)
        {
            // add transaction record
            await this.productTransactionRepository.ProduceAsync(productionNumber, product, quantity, doneby);

            // decrease the quanity of inventories

            // update the quantity of the product
            product.Quantity += quantity;
            await this.productRepository.UpdateProductAsync(product);
        }
    }
}
