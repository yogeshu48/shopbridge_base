using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shopbridge_base.Data;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;

namespace Shopbridge_base.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ILogger<ProductsController> logger;
        public ProductsController(IProductService _productService)
        {
            this.productService = _productService;
        }

       
        [HttpGet]   
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            var data = productService.GetAllProduct();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return Ok(json);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var data = productService.GetProductByProductId(id);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return Ok(json);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            try
            {
                productService.UpdateProduct(product);
                return Ok("Item Updated");
            }
            catch (Exception)
            {
                return Ok("Something Went Wrong");
            }
        }

        
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            try
            {
                await productService.AddProduct(product);
                return Ok("Item Inserted");
            }
            catch (Exception)
            {
                return Ok("Something Went Wrong");
            }
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                productService.DeleteProduct(id);
                return Ok("Item Deleted Successfully");
            }
            catch (Exception)
            {
                return Ok("Something Went Wrong");
            }
        }

        private bool ProductExists(int id)
        {
            var data = productService.GetProductByProductId(id);
            if (data.Any())
            {
                return true;
            }
            return false;
        }
    }
}
