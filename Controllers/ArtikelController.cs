using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvoiceApiProject.Data;
using InvoiceApiProject.Models;

namespace InvoiceApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtikelController : ControllerBase
    {
        private readonly InvoiceApiProjectContext _context;

        public ArtikelController(InvoiceApiProjectContext context)
        {
            _context = context;
        }

        // GET: api/Artikel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artikel>>> GetArtikli()
        {
          if (_context.Artikli == null)
          {
              return NotFound();
          }
            return await _context.Artikli.ToListAsync();
        }

        // GET: api/Artikel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artikel>> GetArtikel(int id)
        {
          if (_context.Artikli == null)
          {
              return NotFound();
          }
            var artikel = await _context.Artikli.FindAsync(id);

            if (artikel == null)
            {
                return NotFound();
            }

            return artikel;
        }

        // PUT: api/Artikel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtikel(int id, Artikel artikel)
        {
            if (id != artikel.Id)
            {
                return BadRequest();
            }

            _context.Entry(artikel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtikelExists(id))
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

        // POST: api/Artikel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artikel>> PostArtikel(Artikel artikel)
        {
          if (_context.Artikli == null)
          {
              return Problem("Entity set 'InvoiceApiProjectContext.Artikli'  is null.");
          }
            _context.Artikli.Add(artikel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtikel", new { id = artikel.Id }, artikel);
        }

        // DELETE: api/Artikel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtikel(int id)
        {
            if (_context.Artikli == null)
            {
                return NotFound();
            }
            var artikel = await _context.Artikli.FindAsync(id);
            if (artikel == null)
            {
                return NotFound();
            }

            _context.Artikli.Remove(artikel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtikelExists(int id)
        {
            return (_context.Artikli?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
