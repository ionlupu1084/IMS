using IMS.CoreBusiness;
using IMS.UseCases.Products.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.Products
{
    public class EditProductUseCase : IEditProductUseCase
    {
        private readonly IProductsRepository ProductRepository;
        public EditProductUseCase(IProductsRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }

        public async Task ExecuteAsync(Product Product)
        {
            await this.ProductRepository.UpdateProductAsync(Product);
        }
    }
}
