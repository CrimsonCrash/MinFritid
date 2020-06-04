using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MinFritidAPI.Data;
using MinFritidAPI.Models;

namespace MinFritidAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AnotherPolicy")]
    [ApiController]
    public class AktivitetBrugerTilmeldtController : ControllerBase
    {
        private readonly MinFritidContext _context;

        public AktivitetBrugerTilmeldtController(MinFritidContext context)
        {
            _context = context;
        }

        // GET: api/AktivitetBrugerTilmeldt
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AktivitetBrugerTilmeldt>>> GetAktivitetBrugerTilmeldt()
        {
            return await _context.AktivitetBrugerTilmeldt.ToListAsync();
        }

        // GET: api/AktivitetBrugerTilmeldt/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AktivitetBrugerTilmeldt>> GetAktivitetBrugerTilmeldt(int id)
        {
            var aktivitetBrugerTilmeldt = await _context.AktivitetBrugerTilmeldt.FindAsync(id);

            if (aktivitetBrugerTilmeldt == null)
            {
                return NotFound();
            }

            return aktivitetBrugerTilmeldt;
        }

        // POST: api/AktivitetBrugerTilmeldt
        [HttpPost]
        public async Task<ActionResult<AktivitetBrugerTilmeldt>> PostAktivitetBrugerTilmeldt(AktivitetBrugerTilmeldt aktivitetBrugerTilmeldt)
        {
            _context.AktivitetBrugerTilmeldt.Add(aktivitetBrugerTilmeldt);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AktivitetBrugerTilmeldtExists(aktivitetBrugerTilmeldt.AktivitetID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAktivitetBrugerTilmeldt", new { id = aktivitetBrugerTilmeldt.AktivitetID }, aktivitetBrugerTilmeldt);
        }

        // DELETE: api/AktivitetBrugerTilmeldt/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AktivitetBrugerTilmeldt>> DeleteAktivitetBrugerTilmeldt(AktivitetBrugerTilmeldt aktivitetBrugerTilmeldt)
        {
            var aktivitet = await _context.AktivitetBrugerTilmeldt.FindAsync(aktivitetBrugerTilmeldt.AktivitetID);
            if (aktivitetBrugerTilmeldt == null)
            {
                return NotFound();
            }

            _context.AktivitetBrugerTilmeldt.Remove(aktivitetBrugerTilmeldt);
            await _context.SaveChangesAsync();

            return aktivitetBrugerTilmeldt;
        }

        private bool AktivitetBrugerTilmeldtExists(int id)
        {
            return _context.AktivitetBrugerTilmeldt.Any(e => e.AktivitetID == id);
        }
    }
}
