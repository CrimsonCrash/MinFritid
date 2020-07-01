using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<Bruger> _userManager;

        public AktivitetBrugerTilmeldtController(MinFritidContext context, UserManager<Bruger> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/AktivitetBrugerTilmeldt
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AktivitetBrugerTilmeldt>>> GetAktivitetBrugerTilmeldt()
        {
            return await _context.AktivitetBrugerTilmeldt.ToListAsync();
        }

        // GET: api/AktivitetBrugerTilmeldt/Aktivitet/5
        [HttpGet("aktivitet/{id}")]
        public async Task<ActionResult> GetListByAktivitetID(int id)
        {
            var tilmeldteBrugere = await _context.AktivitetBrugerTilmeldt.Where(a => a.AktivitetID == id).Select(a => new GetParticipantsDto
            {
                Fornavn = a.Bruger.Fornavn,
                Efternavn = a.Bruger.Efternavn,
                Bynavn = a.Bruger.By.Bynavn,
                Verificeret = a.Bruger.Verificeret
            }).ToListAsync();

            if (tilmeldteBrugere == null)
            {
                return NotFound();
            }

            return new JsonResult(tilmeldteBrugere);
        }

        // GET: api/AktivitetBrugerTilmeldt/Bruger/5e34359b-dd51-4515-b47e-7c9bea9fdfbf
        [HttpGet("bruger/{id}")]
        public async Task<ActionResult> GetListByBrugerID(string id)
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var aktiviteter = await _context.AktivitetBrugerTilmeldt.Where(a => a.BrugerID == userID).Select(a => new GetAktivitetDto
            {
                AktivitetID = a.AktivitetID,
                Titel = a.Aktivitet.Titel,
                Beskrivelse = a.Aktivitet.Beskrivelse,
                Huskeliste = a.Aktivitet.Huskeliste,
                Pris = a.Aktivitet.Pris,
                MaxDeltagere = a.Aktivitet.MaxDeltagere,
                StartTidspunkt = a.Aktivitet.StartTidspunkt,
                SlutTidspunkt = a.Aktivitet.SlutTidspunkt,
                Bynavn = a.Aktivitet.By.Bynavn,
                Aktiv = a.Aktivitet.Aktiv,
            }).ToListAsync();

            if (aktiviteter == null)
            {
                return NotFound();
            }

            foreach (var aktivitet in aktiviteter)
            {
                aktivitet.PladserTilbage = NumberOfSpotsLeft(aktivitet.AktivitetID);
            }

            return new JsonResult(aktiviteter);
        }

        // PUT: api/AktivitetBrugerTilmeldt
        [HttpPut] // TODO: Denne her PUT skal bruges til at give deltagere en ny Prioritet. Den skal dog ikke være i stand til at give eller ændre hvem der er Vært.
        public async Task<ActionResult<AktivitetBrugerTilmeldt>> PutAktivitetBrugerTilmeldt(AktivitetBrugerTilmeldt aktivitetBrugerTilmeldt)
        {
            var abt = await _context.AktivitetBrugerTilmeldt.FindAsync(aktivitetBrugerTilmeldt.AktivitetID, aktivitetBrugerTilmeldt.BrugerID);

            if (abt == null)
            {
                return NotFound("Not found");
            }
            else
            {
                _context.AktivitetBrugerTilmeldt.Update(aktivitetBrugerTilmeldt);
                await _context.SaveChangesAsync();
                return Ok("Updated AktivitetBrugerTilmeldt ");
            }
            //return BadRequest();
        }

        // TODO giv Vært videre
        // PUT: api/AktivitetBrugerTilmeldt
        [HttpPut]
        public async Task<ActionResult<TilmeldteDto>> TransferHostPriority(TilmeldteDto aktivitetBrugerTilmeldt)
        {
            var abt = await _context.AktivitetBrugerTilmeldt.FindAsync(aktivitetBrugerTilmeldt.AktivitetID, aktivitetBrugerTilmeldt.BrugerID);
            var oldHostId = await _context.AktivitetBrugerTilmeldt.Where(a => a.AktivitetID == abt.AktivitetID && a.Prioritet == Prioritet.Vaert).FirstOrDefaultAsync();

            if (abt == null)
            {
                return BadRequest("Brugeren som er du ønsker at gøre til vært for aktiviteten skal være tilmeldt aktiviteten.");
            }
            else if (abt.Prioritet != Prioritet.Vaert)
            {
                _context.AktivitetBrugerTilmeldt.Update(abt);
                await _context.SaveChangesAsync();
                return Ok("Updated AktivitetBrugerTilmeldt ");
            }
            return BadRequest();
        }

        // POST: api/AktivitetBrugerTilmeldt
        [HttpPost]
        public async Task<ActionResult<AktivitetBrugerTilmeldt>> PostAktivitetBrugerTilmeldt(TilmeldteDto Dto)
        {
            if (AktivitetBrugerTilmeldtExists(Dto.AktivitetID, Dto.BrugerID))
            {
                return BadRequest("Brugeren er allerede tilmeldt.");
            }
            if (NumberOfSpotsLeft(Dto.AktivitetID) > 0)
            {
                AktivitetBrugerTilmeldt aktivitetBrugerTilmeldt = new AktivitetBrugerTilmeldt
                {
                    AktivitetID = Dto.AktivitetID,
                    BrugerID = Dto.BrugerID
                };

                await _context.AktivitetBrugerTilmeldt.AddAsync(aktivitetBrugerTilmeldt);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetAktivitetBrugerTilmeldt", new { id = aktivitetBrugerTilmeldt.AktivitetID }, Dto);
            }
            else
            {
                return BadRequest("Aktiviteten har ikke plads til flere deltagere.");
            }
        }

        // DELETE: api/AktivitetBrugerTilmeldt
        [HttpDelete] // TODO Hvordan håndtere vi dette med dem som allerede har betalt?
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

        private bool AktivitetBrugerTilmeldtExists(int aktivitetID, string brugerID)
        {
            return _context.AktivitetBrugerTilmeldt.Any(e => e.AktivitetID == aktivitetID && e.BrugerID == brugerID);
        }
        public int NumberOfSpotsLeft(int aktivitetID) // Returnere antallet af ledige pladser
        {
            int aktivitetBrugerTilmeldt = _context.AktivitetBrugerTilmeldt.Where(a => a.AktivitetID == aktivitetID).ToList().Count();
            int maxAntalDeltagere = _context.Aktivitet.Find(aktivitetID).MaxDeltagere;

            int numberOfSpotsLeft = maxAntalDeltagere - aktivitetBrugerTilmeldt;

            return numberOfSpotsLeft;
        }
    }
}