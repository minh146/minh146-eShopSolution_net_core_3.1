using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Application.Catalog.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPublicProductSevice _publicProductSevice;
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var product = await _publicProductSevice.GetAll();
            return Ok(product);
        }
        public ProductController(IPublicProductSevice publicProductSevice)
        {
            _publicProductSevice = publicProductSevice;
        }
        
    }
}
