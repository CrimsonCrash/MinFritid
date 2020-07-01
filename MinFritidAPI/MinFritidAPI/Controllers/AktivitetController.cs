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
    [EnableCors("AnotherPolicy")]
    [ApiController]
    public class AktivitetController : ControllerBase
    {
        private MinFritidContext _context { get; }

        public AktivitetController(MinFritidContext context)
        {
            _context = context;
        }

        /*// GET: api/Aktivitet
        [HttpGet]
        public IActionResult GetAllAktiviteter()
        {
            return new JsonResult(_context.Aktivitet);
        }*/

        // GET: api/Aktivitet
        [HttpGet]
        public async Task<IActionResult> GetAktiveAktiviteter()
        {
            var aktiviteter = await _context.Aktivitet.Select(a => new GetAktivitetDto
            {
                AktivitetID = a.AktivitetID,
                Titel = a.Titel,
                Beskrivelse = a.Beskrivelse,
                Huskeliste = a.Huskeliste,
                Pris = a.Pris,
                MaxDeltagere = a.MaxDeltagere,
                StartTidspunkt = a.StartTidspunkt,
                SlutTidspunkt = a.SlutTidspunkt,
                Bynavn = a.By.Bynavn,
                Aktiv = a.Aktiv,
            }).Where(a => a.Aktiv == true).ToListAsync();

            if (aktiviteter == null)
            {
                return NotFound("Der er ingen aktiviteter");
            }
            foreach (var aktivitet in aktiviteter)
            {
                aktivitet.PladserTilbage = NumberOfSpotsLeft(aktivitet.AktivitetID);
            }
            return new JsonResult(aktiviteter);
        }
        public int NumberOfSpotsLeft(int aktivitetID) // Returnere antallet af ledige pladser
        {
            int aktivitetBrugerTilmeldt = _context.AktivitetBrugerTilmeldt.Where(a => a.AktivitetID == aktivitetID).ToList().Count();
            int maxAntalDeltagere = _context.Aktivitet.Find(aktivitetID).MaxDeltagere;

            int numberOfSpotsLeft = maxAntalDeltagere - aktivitetBrugerTilmeldt;

            return numberOfSpotsLeft;
        }

        // GET: api/Aktivitet/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAktivitet(int id)
        {
            var aktivitet = await _context.Aktivitet.Select(a => new GetAktivitetDto
            {
                AktivitetID = a.AktivitetID,
                Titel = a.Titel,
                Beskrivelse = a.Beskrivelse,
                Huskeliste = a.Huskeliste,
                Pris = a.Pris,
                MaxDeltagere = a.MaxDeltagere,
                StartTidspunkt = a.StartTidspunkt,
                SlutTidspunkt = a.SlutTidspunkt,
                Bynavn = a.By.Bynavn,
                Aktiv = a.Aktiv,
                Deltagere = a.AktivitetBrugerTilmeldt.Select(t => new GetBrugerDto // Henter listen af tilmeldte brugere
                {
                    BrugerID = t.Bruger.Id,
                    BrugerFornavn = t.Bruger.Fornavn,
                    BrugerEfternavn = t.Bruger.Efternavn,
                    BrugerAktiv = t.Bruger.Aktiv,
                    BrugerVerificeret = t.Bruger.Verificeret,
                    BrugerFoedselsdag = t.Bruger.Foedselsdato,
                    BrugerBynavn = t.Bruger.By.Bynavn,
                    BrugerEmail = t.Bruger.Email
                })
            }).SingleOrDefaultAsync(a => a.AktivitetID == id);
            
            if (aktivitet == null)
            {
                return NotFound();
            }

            aktivitet.PladserTilbage = NumberOfSpotsLeft(aktivitet.AktivitetID);
            return new JsonResult(aktivitet);
        }

        // PUT: api/Aktivitet
        [HttpPut]
        public async Task<IActionResult> PutAktivitet(Aktivitet aktivitet) // TODO: Check rettigheder & brug en Dto i stedet for Aktivitet
        {
            //var PutAktivitet = _context.Aktivitet.FirstOrDefault(Aktivitet => Aktivitet.ID == Id);
            if (aktivitet == null)
            {
                return NotFound("Ikke fundet");
            }
            else
            {
                _context.Aktivitet.Update(aktivitet);
                await _context.SaveChangesAsync();
                return Ok("Opdateret Aktivitet");
            }
            //return BadRequest();
        }

        // POST: api/Aktivitet
        [HttpPost]  // TODO tilmeld opretteren og sæt vedkommende som vært
        public IActionResult PostAktivitet(PostAktivitetDto aktivitet) // TODO: Check om bruger er verificeret
        {
            using (var PostAktivitet = _context)
            {
                if (PostAktivitet != null)
                {
                    var Aktivitet = new Aktivitet 
                    { 
                        Titel = aktivitet.Titel,
                        Beskrivelse = aktivitet.Beskrivelse,
                        AktivitetPostnummer = aktivitet.Postnummer,
                        StartTidspunkt = aktivitet.StartTidspunkt,
                        SlutTidspunkt = aktivitet.SlutTidspunkt,
                        MaxDeltagere = aktivitet.MaxDeltagere,
                        Pris = aktivitet.Pris,
                        Huskeliste = aktivitet.Huskeliste
                    };
                    if (Aktivitet != null)
                    {
                        //var abt = new AktivitetBrugerTilmeldt { AktivitetID = Aktivitet.AktivitetID, BrugerID = aktivitet.BrugerID, Prioritet = Prioritet.Vaert }; // TODO: Find current user.
                        _context.Aktivitet.Add(Aktivitet);
                        //_context.AktivitetBrugerTilmeldt.Add(abt);
                        _context.SaveChanges();
                        return Ok(new { status = 1, message = "Aktivitet oprettet" });
                    }
                }

                return BadRequest(new { status = 0, message = "FEJL: Aktivitet ikke oprettet" });

            }
        }

        // DELETE: api/Aktivitet/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAktivitet(int Id) // TODO: Check rettigheder
        {
            var DeleteAktivitet = _context.Aktivitet.FirstOrDefault(Aktivitet => Aktivitet.AktivitetID == Id);
            if (DeleteAktivitet != null)
            {
                _context.Aktivitet.Remove(DeleteAktivitet);
                _context.SaveChanges();
                return Ok("Aktivitet Fjernet");
            }
            else
            {
                return NotFound("Ikke fundet");
            }
        }

        // PUT: api/aktivitet/deaktiv/5
        [HttpPut("deaktiv/{id}")]
        public IActionResult DeaktiverAktivitet(int Id) // TODO: Check rettigheder
        {
            var aktivitet = _context.Aktivitet.FirstOrDefault(Aktivitet => Aktivitet.AktivitetID == Id);
            if (aktivitet == null)
            {
                return NotFound("Not found");
            }
            if (aktivitet.AktivitetID == Id)
            {
                aktivitet.Aktiv = false;
                _context.Aktivitet.Update(aktivitet);
                _context.SaveChanges();
                return Ok("Aktivitet sat til ikke aktiv");
            }
            return BadRequest();
        }

        // PUT: api/aktivitet/aktiv/5
        [HttpPut("aktiv/{id}")]
        public IActionResult GenaktiverAktivitet(int Id) // TODO: Check rettigheder
        {
            var aktivitet = _context.Aktivitet.FirstOrDefault(Aktivitet => Aktivitet.AktivitetID == Id);
            if (aktivitet == null)
            {
                return NotFound("Not found");
            }
            if (aktivitet.AktivitetID == Id && aktivitet.Aktiv == false)
            {
                aktivitet.Aktiv = true;
                _context.Aktivitet.Update(aktivitet);
                _context.SaveChanges();
                return Ok("Aktivitet sat til aktiv");
            }
            return BadRequest("Der opstod en fejl. Prøv at check om aktiviteten allerede er aktiv.");
        }

        private bool AktivitetExists(int id)
        {
            return _context.Aktivitet.Any(e => e.AktivitetID == id);
        }
    }
}
