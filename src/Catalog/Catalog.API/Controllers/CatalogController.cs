using Catalog.API.Entities;
using Catalog.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System;

namespace Catalog.API.Controllers
{
    [ApiController]
    //[Route("api/v1/{controller}")]
    [Route("api/v1/Catalog")]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public CatalogController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Product),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<Product>>> getProducts()
        {
            var products = await _productRepository.getProducts();
            return Ok(products);
        }
        [HttpGet]
        [HttpGet("",Name ="GetProduct")]
        [Route("/{id}")]
        public async Task<ActionResult<Product>> getProducts(string id)
        {
            var product = await _productRepository.getProduct(id);
            return Ok(product);
        }

        [HttpGet]
        [Route("/{Name}")]
        public async Task<ActionResult<IEnumerable<Product>>> getProdyctByName(string Name)
        {
            var products = await _productRepository.getProductByName(Name);
            return Ok(products);
        }

        [Route("/{action}/{Category}")]
        [ProducesResponseType(typeof(Product),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> getProductByCategory(string Category)
        {
            var products = await _productRepository.getProductByCategory(Category);
            return Ok(products);
        }

        [HttpPost ]
        [ProducesResponseType(typeof(Product),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> CreateProduct([FromBody]Product newProduct)
        {
            var product = await _productRepository.createProdct(newProduct);

            return CreatedAtRoute("GetProduct", new { id = newProduct.Id}, newProduct);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Product),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] Product updateProduct)
        {
            return Ok(await _productRepository.updateProduct(updateProduct));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> deleteProduct(string id)
        {
            return Ok(await _productRepository.deleteProduct(id));
        }

    }
}
