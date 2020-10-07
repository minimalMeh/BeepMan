using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeepMan.Api.Interfaces;
using BeepMan.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BeepMan.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]ProductViewModel product)
        {
            var result = await this._productService.CreateProductAsync(product);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
