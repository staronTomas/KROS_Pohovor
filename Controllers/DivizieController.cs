using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KROS_Pohovor.Models;

namespace KROS_Pohovor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivizieController : ControllerBase
    {
        private readonly KrosZadanieContext _context;

        public DivizieController(KrosZadanieContext context)
        {
            _context = context;
        }

        // GET: api/Divizie
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Divizie>>> GetDivizies()
        {
            return await _context.Divizies.ToListAsync();
        }

        // GET: api/Divizie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Divizie>> GetDivizie(int id)
        {
            var divizie = await _context.Divizies.FindAsync(id);

            if (divizie == null)
            {
                return NotFound();
            }

            return divizie;
        }

        // PUT: api/Divizie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDivizie(int id, Divizie divizie)
        {
            if (id != divizie.KodDivizie)
            {
                return BadRequest("Kód divízie sa nesmie zmeniť");
            }

            _context.Entry(divizie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DivizieExists(id))
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

        // POST: api/Divizie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Divizie>> PostDivizie(Divizie divizie)
        {
            _context.Divizies.Add(divizie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DivizieExists(divizie.KodDivizie))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDivizie", new { id = divizie.KodDivizie }, divizie);
        }

        // DELETE: api/Divizie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDivizie(int id)
        {
            var divizie = await _context.Divizies.FindAsync(id);
            if (divizie == null)
            {
                return NotFound();
            }

            _context.Divizies.Remove(divizie);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool DivizieExists(int id)
        {
            return _context.Divizies.Any(e => e.KodDivizie == id);
        }
    }
}
