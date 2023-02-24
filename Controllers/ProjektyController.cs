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
    public class ProjektyController : ControllerBase
    {
        private readonly KrosZadanieContext _context;

        public ProjektyController(KrosZadanieContext context)
        {
            _context = context;
        }

        // GET: api/Projekty
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projekty>>> GetProjekties()
        {
            return await _context.Projekties.ToListAsync();
        }

        // GET: api/Projekty/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Projekty>> GetProjekty(int id)
        {
            var projekty = await _context.Projekties.FindAsync(id);

            if (projekty == null)
            {
                return NotFound();
            }

            return projekty;
        }

        // PUT: api/Projekty/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjekty(int id, Projekty projekty)
        {
            if (id != projekty.KodProjektu)
            {
                return BadRequest("Kód projektu sa nesmie zmeniť");
            }

            _context.Entry(projekty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjektyExists(id))
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

        // POST: api/Projekty
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Projekty>> PostProjekty(Projekty projekty)
        {
            _context.Projekties.Add(projekty);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProjektyExists(projekty.KodProjektu))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProjekty", new { id = projekty.KodProjektu }, projekty);
        }

        // DELETE: api/Projekty/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjekty(int id)
        {
            var projekty = await _context.Projekties.FindAsync(id);
            if (projekty == null)
            {
                return NotFound();
            }

            _context.Projekties.Remove(projekty);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjektyExists(int id)
        {
            return _context.Projekties.Any(e => e.KodProjektu == id);
        }
    }
}
