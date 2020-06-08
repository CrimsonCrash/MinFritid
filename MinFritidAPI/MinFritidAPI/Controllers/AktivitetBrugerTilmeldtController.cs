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

        // GET: api/AktivitetBrugerTilmeldt/Aktivitet/5
        [HttpGet("aktivitet/{id}")]
        public async Task<ActionResult<IEnumerable<AktivitetBrugerTilmeldt>>> GetListByAktivitetID(int id)
        {
            var aktivitetBrugerTilmeldt = await _context.AktivitetBrugerTilmeldt.Where(a => a.AktivitetID == id).ToListAsync();

            if (aktivitetBrugerTilmeldt == null)
            {
                return NotFound();
            }

            return aktivitetBrugerTilmeldt;
        }

        // GET: api/AktivitetBrugerTilmeldt/Bruger/5
        [HttpGet("bruger/{id}")]
        public async Task<ActionResult<IEnumerable<AktivitetBrugerTilmeldt>>> GetListByBrugerID(int id)
        {
            var aktivitetBrugerTilmeldt = await _context.AktivitetBrugerTilmeldt.Where(b => b.BrugerID == id).ToListAsync();

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
            if (MaxParticipantsReached(aktivitetBrugerTilmeldt.AktivitetID) == false)
            {
                _context.AktivitetBrugerTilmeldt.Add(aktivitetBrugerTilmeldt);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (AktivitetBrugerTilmeldtExists(aktivitetBrugerTilmeldt.AktivitetID, aktivitetBrugerTilmeldt.BrugerID))
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
            else
            {
                return BadRequest("Aktiviteten har ikke plads til flere deltagere.");
            }
        }

        // DELETE: api/AktivitetBrugerTilmeldt
        [HttpDelete]
        public async Task<ActionResult<AktivitetBrugerTilmeldt>> DeleteAktivitetBrugerTilmeldt(AktivitetBrugerTilmeldt aktivitetBrugerTilmeldt)
        {
            var abt = await _context.AktivitetBrugerTilmeldt.FindAsync(aktivitetBrugerTilmeldt.AktivitetID, aktivitetBrugerTilmeldt.BrugerID);
            if (abt == null)
            {
                return NotFound();
            }

            _context.AktivitetBrugerTilmeldt.Remove(abt);
            await _context.SaveChangesAsync();

            return abt;
        }

        private bool AktivitetBrugerTilmeldtExists(int aktivitetID, int brugerID)
        {
            return _context.AktivitetBrugerTilmeldt.Any(e => e.AktivitetID == aktivitetID && e.BrugerID == brugerID);
        }

        public bool MaxParticipantsReached(int aktivitetID)
        {
            var aktivitetBrugerTilmeldt = _context.AktivitetBrugerTilmeldt.Where(a => a.AktivitetID == aktivitetID).ToList();
            var aktivitet = _context.Aktivitet.Find(aktivitetID);
            
            if (aktivitetBrugerTilmeldt.Count() >= aktivitet.MaxDeltagere)
            {
                return true;
            }

            return false;
        }
    }
}
