﻿using IMS.CoreBusiness;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IProductTransactionRepository
    {
        Task ProduceAsync(string productionNumber, Product product, int quantity, string doneby);
        Task SellProductAsync(string salesOrderNumber, Product product, int quantity, double unitPrice, string doneBy);
    }
}