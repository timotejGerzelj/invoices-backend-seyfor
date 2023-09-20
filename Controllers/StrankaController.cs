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
    public class StrankaController : ControllerBase
    {
        private readonly InvoiceApiProjectContext _context;

        public StrankaController(InvoiceApiProjectContext context)
        {
            _context = context;
        }

        // GET: api/Stranka
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stranka>>> GetStranke()
        {
          if (_context.Stranke == null)
          {
              return NotFound();
          }
            return await _context.Stranke.ToListAsync();
        }

        // GET: api/Stranka/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stranka>> GetStranka(int id)
        {
          if (_context.Stranke == null)
          {
              return NotFound();
          }
            var stranka = await _context.Stranke.FindAsync(id);

            if (stranka == null)
            {
                return NotFound();
            }

            return stranka;
        }

        // PUT: api/Stranka/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStranka(int id, Stranka stranka)
        {
            if (id != stranka.Id)
            {
                return BadRequest();
            }

            _context.Entry(stranka).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StrankaExists(id))
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

        // POST: api/Stranka
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Stranka>> PostStranka(Stranka stranka)
        {
          if (_context.Stranke == null)
          {
              return Problem("Entity set 'InvoiceApiProjectContext.Stranke'  is null.");
          }
            _context.Stranke.Add(stranka);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStranka", new { id = stranka.Id }, stranka);
        }

        // DELETE: api/Stranka/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStranka(int id)
        {
            if (_context.Stranke == null)
            {
                return NotFound();
            }
            var stranka = await _context.Stranke.FindAsync(id);
            if (stranka == null)
            {
                return NotFound();
            }

            _context.Stranke.Remove(stranka);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StrankaExists(int id)
        {
            return (_context.Stranke?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
