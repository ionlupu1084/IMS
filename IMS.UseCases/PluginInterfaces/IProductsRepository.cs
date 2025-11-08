using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetProductsByNameAsync(string name);
        Task AddProductAsync(Product product);
        Task DeleteProductByIdAsync(int productID);
        
        Task<Product> GetProductByIDAsync(int productID);
        
        Task UpdateProductAsync(Product product);
    }
}
