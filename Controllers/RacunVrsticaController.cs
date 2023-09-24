using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvoiceApiProject.Data;

namespace InvoiceApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacunVrsticaController : ControllerBase
    {
        private readonly InvoiceApiProjectContext _context;

        public RacunVrsticaController(InvoiceApiProjectContext context)
        {
            _context = context;
        }

        // GET: api/RacunVrstica
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RacunVrstica>>> GetLineItems()
        {
          if (_context.LineItems == null)
          {
              return NotFound();
          }
            return await _context.LineItems.ToListAsync();
        }

        // GET: api/RacunVrstica/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RacunVrstica>> GetRacunVrstica(int id)
        {
          if (_context.LineItems == null)
          {
              return NotFound();
          }
            var racunVrstica = await _context.LineItems.FindAsync(id);

            if (racunVrstica == null)
            {
                return NotFound();
            }

            return racunVrstica;
        }

        // PUT: api/RacunVrstica/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRacunVrstica(int id, RacunVrstica racunVrstica)
        {
            if (id != racunVrstica.Id)
            {
                return BadRequest();
            }

            _context.Entry(racunVrstica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RacunVrsticaExists(id))
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

        // POST: api/RacunVrstica
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RacunVrstica>> PostRacunVrstica(RacunVrstica racunVrstica)
        {
         if (_context.LineItems == null)
    {
        return Problem("Entity set 'InvoiceApiProjectContext.LineItems' is null.");
    }

    try
    {
        _context.LineItems.Add(racunVrstica);
        await _context.SaveChangesAsync();

        // Log the inserted RacunVrstica data
        Console.WriteLine($"Inserted RacunVrstica: Id={racunVrstica.Id}, Kolicina={racunVrstica.Kolicina}, RacunId={racunVrstica.RacunId}, ArtikelId={racunVrstica.ArtikelId}");
        
        return CreatedAtAction("GetRacunVrstica", new { id = racunVrstica.Id }, racunVrstica);
    }
    catch (Exception ex)
    {
        // Log any exceptions
        Console.WriteLine($"Exception during RacunVrstica insertion: {ex}");
        return Problem("An error occurred while processing your request.", statusCode: 500);
    }        }

        // DELETE: api/RacunVrstica/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRacunVrstica(int id)
        {
            if (_context.LineItems == null)
            {
                return NotFound();
            }
            var racunVrstica = await _context.LineItems.FindAsync(id);
            if (racunVrstica == null)
            {
                return NotFound();
            }

            _context.LineItems.Remove(racunVrstica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RacunVrsticaExists(int id)
        {
            return (_context.LineItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
