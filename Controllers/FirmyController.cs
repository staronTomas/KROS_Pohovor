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
    public class FirmyController : ControllerBase
    {
        private readonly KrosZadanieContext _context;

        public FirmyController(KrosZadanieContext context)
        {
            _context = context;
        }

        // GET: api/Firmy
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Firmy>>> GetFirmies()
        {
            return await _context.Firmies.ToListAsync();
        }

        // GET: api/Firmy/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Firmy>> GetFirmy(int id)
        {
            var firmy = await _context.Firmies.FindAsync(id);

            if (firmy == null)
            {
                return NotFound();
            }

            return firmy;
        }

        // PUT: api/Firmy/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFirmy(int id, Firmy firmy)
        {
            if (id != firmy.KodFirmy)
            {
                return BadRequest("Kód firmy sa nesmie zmeniť");
            }

            _context.Entry(firmy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FirmyExists(id))
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

        // POST: api/Firmy
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Firmy>> PostFirmy(Firmy firmy)
        {
            _context.Firmies.Add(firmy);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FirmyExists(firmy.KodFirmy))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFirmy", new { id = firmy.KodFirmy }, firmy);
        }

        // DELETE: api/Firmy/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFirmy(int id)
        {
            var firmy = await _context.Firmies.FindAsync(id);
            if (firmy == null)
            {
                return NotFound();
            }

            _context.Firmies.Remove(firmy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FirmyExists(int id)
        {
            return _context.Firmies.Any(e => e.KodFirmy == id);
        }
    }
}
