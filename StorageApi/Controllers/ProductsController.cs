using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorageApi.Models;

namespace StorageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StorageContext _context;

        public ProductsController(StorageContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductDto()
        {
            return await _context.ProductDto.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductDto(int id)
        {
            var productDto = await _context.ProductDto.FindAsync(id);

            if (productDto == null)
            {
                return NotFound();
            }

            return productDto;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductDto(int id, ProductDto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(productDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductDtoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProductDto(ProductDto productDto)
        {
            _context.ProductDto.Add(productDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductDto", new { id = productDto.Id }, productDto);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDto(int id)
        {
            var productDto = await _context.ProductDto.FindAsync(id);
            if (productDto == null)
            {
                return NotFound();
            }

            _context.ProductDto.Remove(productDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductDtoExists(int id)
        {
            return _context.ProductDto.Any(e => e.Id == id);
        }
    }
}
