using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.Inventories
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductsRepository productRepository;
        public DeleteProductUseCase(IProductsRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        public async Task ExecuteAsync(int productID)
        {
            await this.productRepository.DeleteProductByIdAsync(productID);
        }
    }
}
