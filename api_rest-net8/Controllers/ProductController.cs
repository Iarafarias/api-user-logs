using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using api_rest.Domain.Models;
using api_rest.Domain.Services;
using api_rest.Resources;
using Microsoft.AspNetCore.Authorization;

namespace api_rest.Controllers
{
    [Route("/api/[controller]")]
    [Authorize()]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductResource>> ListAsync()
        {
            var products = await _productService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return resources;
        }

        // GET /api/product/{id} > Novo EndPOint 
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResource>> GetByIdAsync(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            if (!result.Success)
                return NotFound(result.Message);

            var resource = _mapper.Map<Product, ProductResource>(result.Resource);
            return Ok(resource);
        }

        // POST /api/product
        [HttpPost]
        public async Task<ActionResult<ProductResource>> PostAsync([FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _productService.SaveAsync(product);

            if (!result.Success)
                return BadRequest(result.Message);

            var productResource = _mapper.Map<Product, ProductResource>(result.Resource);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = productResource.Id }, productResource);
        }

        // PUT /api/product/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductResource>> PutAsync(int id, [FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _productService.UpdateAsync(id, product);

            if (!result.Success)
                return BadRequest(result.Message);

            var productResource = _mapper.Map<Product, ProductResource>(result.Resource);
            return Ok(productResource);
        }

        // DELETE /api/product/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _productService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }



    }


}
