using Microsoft.Extensions.Logging;
using Shopbridge_base.Data.Repository;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository _product;
        private readonly ILogger<ProductService> logger;

        public ProductService(IRepository product)
        {
            _product = product;
        }
        //Get Product Details By Product Id  
        public IEnumerable<Product> GetProductByProductId(int productId)
        {
            return _product.GetAll().Where(x => x.Product_Id == productId).ToList();
        }
        //GET All Product Details   
        public IEnumerable<Product> GetAllProduct()
        {
            try
            {
                return _product.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Add Product  
        public async Task<Product> AddProduct(Product product)
        {
            return await _product.Create(product);
        }
        //Delete Product   
        public bool DeleteProduct(int productId)
        {

            try
            {
                var DataList = _product.GetAll().Where(x => x.Product_Id == productId).ToList();
                foreach (var item in DataList)
                {
                    _product.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }

        }
        //Update Product Details  
        public bool UpdateProduct(Product product)
        {
            try
            {
                var DataList = _product.GetAll().Where(x => x.Product_Id == product.Product_Id).ToList();
                if(DataList != null)
                {
                    _product.Update(product);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
