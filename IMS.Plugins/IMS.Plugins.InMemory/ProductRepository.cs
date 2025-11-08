using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class ProductRepository : IProductsRepository
    {
        private List<Product> _products;
        public ProductRepository() { 
        
        _products=new List<Product>()
        {
            new Product { ProductID=1, ProductName="Byke", Quantity=10, Price=150},
            new Product { ProductID=2, ProductName="Car", Quantity=10, Price=15}

        };

        }

        public Task AddProductAsync(Product Product)
        {
            if (_products.Any(x => x.ProductName.Equals(Product.ProductName, StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }
            var maxID = _products.Max(x => x.ProductID);
            Product.ProductID = maxID + 1;

            _products.Add(Product);
            return Task.CompletedTask;

        }

        public  Task DeleteProductByIdAsync(int productID)
        {
            if (_products.Any(x => x.ProductID == productID))
            {
                this._products.Remove(_products.FirstOrDefault(x => x.ProductID== productID));
                return  Task.CompletedTask;
            }

                return Task.CompletedTask;

        }

        public async Task<Product> GetProductByIDAsync(int ProductID)
        {
            return await Task.FromResult(_products.First(x  => x.ProductID == ProductID));
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_products);
            return _products.Where(x => x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public Task UpdateProductAsync(Product Product)
        {
            if (_products.Any(x =>x.ProductID!= Product.ProductID &&
            x.ProductName.Equals(Product.ProductName,StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }
            var invToUpdate=_products.FirstOrDefault(x=> x.ProductID == Product.ProductID);
            if (invToUpdate != null)
            {
                invToUpdate.ProductName = Product.ProductName;
                invToUpdate.Quantity = Product.Quantity;
                invToUpdate.Price = Product.Price;
            }
            return Task.CompletedTask;
        }
    }
}
