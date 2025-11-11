using IMS.CoreBusiness;
using IMS.UseCases.Products.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.products
{
    public class AddProductUseCase : IAddProductUseCase
    {
        private readonly IProductsRepository productRepository;
        public AddProductUseCase(IProductsRepository ProductRepository)
        {
            this.productRepository = ProductRepository;
        }



        public async Task ExecuteAsync(Product Product)
        {
            await this.productRepository.AddProductAsync(Product);
        }
    }
}
