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
    public class OrganizacijaController : ControllerBase
    {
        private readonly InvoiceApiProjectContext _context;

        public OrganizacijaController(InvoiceApiProjectContext context)
        {
            _context = context;
        }

        // GET: api/Organizacija
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organizacija>>> GetOrganizacije()
        {
          if (_context.Organizacije == null)
          {
              return NotFound();
          }
            return await _context.Organizacije.ToListAsync();
        }

        // GET: api/Organizacija/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Organizacija>> GetOrganizacija(int id)
        {
          if (_context.Organizacije == null)
          {
              return NotFound();
          }
            var organizacija = await _context.Organizacije.FindAsync(id);

            if (organizacija == null)
            {
                return NotFound();
            }

            return organizacija;
        }

        // PUT: api/Organizacija/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizacija(int id, Organizacija organizacija)
        {
            if (id != organizacija.Id)
            {
                return BadRequest();
            }

            _context.Entry(organizacija).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizacijaExists(id))
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

        // POST: api/Organizacija
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Organizacija>> PostOrganizacija(Organizacija organizacija)
        {
          if (_context.Organizacije == null)
          {
              return Problem("Entity set 'InvoiceApiProjectContext.Organizacije'  is null.");
          }
            _context.Organizacije.Add(organizacija);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganizacija", new { id = organizacija.Id }, organizacija);
        }

        // DELETE: api/Organizacija/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizacija(int id)
        {
            if (_context.Organizacije == null)
            {
                return NotFound();
            }
            var organizacija = await _context.Organizacije.FindAsync(id);
            if (organizacija == null)
            {
                return NotFound();
            }

            _context.Organizacije.Remove(organizacija);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrganizacijaExists(int id)
        {
            return (_context.Organizacije?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
