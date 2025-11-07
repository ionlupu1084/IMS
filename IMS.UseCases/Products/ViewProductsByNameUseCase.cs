using IMS.CoreBusiness;
using IMS.UseCases.Inventories;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Products
{
    public class ViewProductsByNameUseCase : IViewProductsByNameUseCase
    {
        private readonly IProductsRepository productsRepository;

        public ViewProductsByNameUseCase(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public async Task<IEnumerable<Product>> ExecuteAsync(string name = "")
        {
            return await productsRepository.GetProductsByNameAsync(name);
        }
    }
}
