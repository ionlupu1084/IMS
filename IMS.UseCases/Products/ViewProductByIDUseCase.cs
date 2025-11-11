using IMS.CoreBusiness;
using IMS.UseCases.Products.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace IMS.UseCases.Products
{
    public class ViewProductByIDUseCase : IViewProductByIDUseCase
    {
        private readonly IProductsRepository ProductRepository;

        public ViewProductByIDUseCase(IProductsRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }
        public async Task<Product> ExecuteAsync(int ProductID = 1)
        {
            return await this.ProductRepository.GetProductByIDAsync(ProductID);
        }
    }
}
