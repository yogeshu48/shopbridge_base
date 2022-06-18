using Shopbridge_base.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Services.Interfaces
{
    public interface IProductService
    {
        public IEnumerable<Product> GetProductByProductId(int productId);
        public IEnumerable<Product> GetAllProduct();
        public Task<Product> AddProduct(Product product);
        public bool DeleteProduct(int productId);
        public bool UpdateProduct(Product product);
    }
}
