using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvoiceApiProject.Data;
using InvoiceApiProject.Models;

namespace InvoiceApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacunController : ControllerBase
    {
        private readonly InvoiceApiProjectContext _context;

        public RacunController(InvoiceApiProjectContext context)
        {
            _context = context;
        }

        // GET: api/Racun
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Racun>>> GetRacuni()
        {
          if (_context.Racuni == null)
          {
              return NotFound();
          }
            var racuni = await _context.Racuni.Include(r => r.Stranka)
            .Include(r => r.Organizacija)
            .ToListAsync();

            return racuni;

        }

        // GET: api/Racun/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Racun>> GetRacun(int id)
        {
          if (_context.Racuni == null)
          {
              return NotFound();
          }
            var racun = await _context.Racuni.FindAsync(id);

            if (racun == null)
            {
                return NotFound();
            }

            return racun;
        }

        // PUT: api/Racun/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRacun(int id, Racun racun)
        {
            if (id != racun.Id)
            {
                return BadRequest();
            }

            _context.Entry(racun).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RacunExists(id))
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

        // POST: api/Racun
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Racun>> PostRacun(Racun racun)
        {
          if (_context.Racuni == null)
          {
              return Problem("Entity set 'AppContext.Racuni'  is null.");
          }
            _context.Racuni.Add(racun);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRacun", new { id = racun.Id }, racun);
        }

        // DELETE: api/Racun/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRacun(int id)
        {
            if (_context.Racuni == null)
            {
                return NotFound();
            }
            var racun = await _context.Racuni.FindAsync(id);
            if (racun == null)
            {
                return NotFound();
            }

            _context.Racuni.Remove(racun);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RacunExists(int id)
        {
            return (_context.Racuni?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
