﻿using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.InMemory
{
    public class ProductTransactionRepository : IProductTransactionRepository
    {
        public List<ProductTransaction> _productTransactions = new List<ProductTransaction>();

        private readonly IProductRepository productRepository;
        private readonly IInventoryTransactionRepository inventoryTransactionRepository;
        private readonly InventoryRepository inventoryRepository;

        public ProductTransactionRepository()
        {
            this.inventoryTransactionRepository = new InventoryTransactionRepository();
            this.inventoryRepository = new InventoryRepository();
            this.productRepository = new ProductRepository();
        }
        public ProductTransactionRepository(
                IProductRepository productRepository,
                IInventoryTransactionRepository inventoryTransactionRepository,
                InventoryRepository inventoryRepository)
        {
            this.productRepository = productRepository;
            this.inventoryTransactionRepository = inventoryTransactionRepository;
            this.inventoryRepository = inventoryRepository;
        }
        public async Task ProduceAsync(string productionNumber, Product product, int quantity, string doneby)
        {
            var prod = await this.productRepository.GetProductByIdAsync(product.ProductId);
            if ( prod != null)
            {
                foreach(var pi in prod.ProductInventories)
                {
                    if (pi.Inventory != null)
                    {
                        // add inventory transaction
                        this.inventoryTransactionRepository.ProduceAsync(productionNumber,
                            pi.Inventory,
                            pi.InventoryQuantity * quantity,
                            doneby,
                            -1);

                        // decrease the inventories
                        var inv = await this.inventoryRepository.GetInventoryByIdAsync(pi.InventoryId);
                        inv.Quantity -= pi.InventoryQuantity * quantity;

                        await this.inventoryRepository.UpdateInventoryAsync(inv);
                    }
                }
            }

            // add production transaction
            this._productTransactions.Add(new ProductTransaction
            {
                ProductionNumber = productionNumber,
                ProductId = product.ProductId,
                QuantityBefore = product.Quantity,
                ActivityType = ProductTransactionType.ProduceProduct,
                QuantityAfter = product.Quantity + quantity,
                TransactionDate = DateTime.Now,
                DoneBy = doneby
            });
        }
    }
}
