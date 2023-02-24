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
    public class OddeleniaController : ControllerBase
    {
        private readonly KrosZadanieContext _context;

        public OddeleniaController(KrosZadanieContext context)
        {
            _context = context;
        }

        // GET: api/Oddelenia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Oddelenium>>> GetOddelenia()
        {
            return await _context.Oddelenia.ToListAsync();
        }

        // GET: api/Oddelenia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Oddelenium>> GetOddelenium(int id)
        {
            var oddelenium = await _context.Oddelenia.FindAsync(id);

            if (oddelenium == null)
            {
                return NotFound();
            }

            return oddelenium;
        }

        // PUT: api/Oddelenia/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOddelenium(int id, Oddelenium oddelenium)
        {
            if (id != oddelenium.KodOddelenia)
            {
                return BadRequest("Kód oddelenia sa nesmie zmeniť");
            }

            _context.Entry(oddelenium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OddeleniumExists(id))
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

        // POST: api/Oddelenia
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Oddelenium>> PostOddelenium(Oddelenium oddelenium)
        {
            _context.Oddelenia.Add(oddelenium);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OddeleniumExists(oddelenium.KodOddelenia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOddelenium", new { id = oddelenium.KodOddelenia }, oddelenium);
        }

        // DELETE: api/Oddelenia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOddelenium(int id)
        {
            var oddelenium = await _context.Oddelenia.FindAsync(id);
            if (oddelenium == null)
            {
                return NotFound();
            }

            _context.Oddelenia.Remove(oddelenium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OddeleniumExists(int id)
        {
            return _context.Oddelenia.Any(e => e.KodOddelenia == id);
        }
    }
}
