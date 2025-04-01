using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CategoriaApi.Models;

namespace categoriaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaItemController : ControllerBase
    {
        private readonly CategoriaContext _context;

        public CategoriaItemController(CategoriaContext context)
        {
            _context = context;
        }

        // GET: api/CategoriaItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaItem>>> GetCategoriaItems()
        {
            return await _context.CategoriaItems.ToListAsync();
        }

        // GET: api/CategoriaItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaItem>> GetCategoriaItem(long id)
        {
            var categoriaItem = await _context.CategoriaItems.FindAsync(id);

            if (categoriaItem == null)
            {
                return NotFound();
            }

            return categoriaItem;
        }

        // PUT: api/CategoriaItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriaItem(long id, CategoriaItem categoriaItem)
        {
            if (id != categoriaItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoriaItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaItemExists(id))
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

        // POST: api/CategoriaItem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoriaItem>> PostCategoriaItem(CategoriaItem categoriaItem)
        {
            _context.CategoriaItems.Add(categoriaItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoriaItem", new { id = categoriaItem.Id }, categoriaItem);
        }

        // DELETE: api/CategoriaItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriaItem(long id)
        {
            var categoriaItem = await _context.CategoriaItems.FindAsync(id);
            if (categoriaItem == null)
            {
                return NotFound();
            }

            _context.CategoriaItems.Remove(categoriaItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaItemExists(long id)
        {
            return _context.CategoriaItems.Any(e => e.Id == id);
        }
    }
}
