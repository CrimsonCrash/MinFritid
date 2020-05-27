using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinFritidAPI.Data;
using MinFritidAPI.Models;

namespace MinFritidAPI.Controllers
{
    [Route("api/aktivitet")]
    [ApiController]
    public class AktivitetController : ControllerBase
    {
        private MinFritidContext _context { get; }

        public AktivitetController(MinFritidContext context)
        {
            _context = context;
        }

        // GET: api/Aktivitet
        [HttpGet]
        [EnableCors("AnotherPolicy")]
        public IActionResult GetAllAktivitets()
        {
            return new JsonResult(_context.Aktivitets);
        }

        // GET: api/Aktivitet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aktivitet>> GetAktivitet(int id)
        {
            var aktivitet = await _context.Aktivitets.FindAsync(id);

            if (aktivitet == null)
            {
                return NotFound();
            }

            return aktivitet;
        }

        // PUT: api/Aktivitet/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAktivitet(int id, Aktivitet aktivitet)
        {
            if (id != aktivitet.AktivitetID)
            {
                return BadRequest();
            }

            _context.Entry(aktivitet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AktivitetExists(id))
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

        // POST: api/Aktivitet
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Aktivitet>> PostAktivitet(Aktivitet aktivitet)
        {
            _context.Aktivitets.Add(aktivitet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAktivitet", new { id = aktivitet.AktivitetID }, aktivitet);
        }

        // DELETE: api/Aktivitet/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Aktivitet>> DeleteAktivitet(int id)
        {
            var aktivitet = await _context.Aktivitets.FindAsync(id);
            if (aktivitet == null)
            {
                return NotFound();
            }

            _context.Aktivitets.Remove(aktivitet);
            await _context.SaveChangesAsync();

            return aktivitet;
        }

        private bool AktivitetExists(int id)
        {
            return _context.Aktivitets.Any(e => e.AktivitetID == id);
        }
    }
}
