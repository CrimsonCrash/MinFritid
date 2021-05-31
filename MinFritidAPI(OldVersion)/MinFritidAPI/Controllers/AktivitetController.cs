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

        // GET: api/Aktivitet
        [HttpGet]
        public IActionResult GetAllAktiviteter()
        {
            return new JsonResult(_context.Aktivitet);
        }

        // GET: api/Aktivitet/5
        [HttpGet("{id}")]
        public IActionResult GetAktivitet(int id)
        {
            var aktivitet = _context.Aktivitet.Include("AktivitetBrugerTilmeldt").Select(a => new AktivitetDto
            {
                AktivitetID = a.AktivitetID,
                Titel = a.Titel,
                Beskrivelse = a.Beskrivelse,
                Huskeliste = a.Huskeliste,
                Pris = a.Pris,
                MaxDeltagere = a.MaxDeltagere,
                StartTidspunkt = a.StartTidspunkt,
                SlutTidspunkt = a.SlutTidspunkt,
                Postnummer = a.AktivitetPostnummer,
                Aktiv = a.Aktiv,
                
                Deltagere = a.AktivitetBrugerTilmeldt.Select(t => new AktivitetsBrugerDto
                {
                    BrugerID = t.Bruger.ID,
                    BrugerFornavn = t.Bruger.Fornavn,
                    BrugerEfternavn = t.Bruger.Efternavn,
                    BrugerAktiv = t.Bruger.Aktiv,
                    BrugerFoedselsdag = t.Bruger.Foedselsdato,
                    BrugerPostnummer = t.Bruger.BrugerPostnummer,
                    BrugerEmail = t.Bruger.Email
                })
            }).Where(a => a.AktivitetID == id);

            if (aktivitet == null)
            {
                return NotFound();
            }
            
            return new JsonResult(aktivitet);
        }

        // PUT: api/Aktivitet/5
        [HttpPut("{id}")]
        public IActionResult PutAktivitet(int Id, Aktivitet aktivitet)
        {
            //var PutAktivitet = _context.Aktivitet.FirstOrDefault(Aktivitet => Aktivitet.ID == Id);
            if (aktivitet == null)
            {
                return NotFound("Ikke fundet");
            }
            if (aktivitet.AktivitetID == Id)
            {
                _context.Aktivitet.Update(aktivitet);
                _context.SaveChanges();
                return Ok("Opdateret Aktivitet");
            }
            return BadRequest();
            
        }

        // POST: api/Aktivitet
        [HttpPost]
        public IActionResult PostAktivitet(Aktivitet aktivitet)
        {
            using (var PostAktivitet = _context)
            {
                if (PostAktivitet != null)
                {
                    _context.Aktivitet.Add(aktivitet);
                    _context.SaveChanges();
                    return Ok("Tilfoejet Aktivitet");
                }
                else
                {
                    return NotFound("Ikke Tilfoejet");
                }
            }
        }

        // DELETE: api/Aktivitet/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAktivitet(int Id)
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
        public IActionResult DeaktiverAktivitet(int Id)
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
                return Ok("Updated Aktivitet Deaktiveret");
            }
            return BadRequest();
        }

        // PUT: api/aktivitet/aktiv/5
        [HttpPut("aktiv/{id}")]
        public IActionResult GenaktiverAktivitet(int Id)
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
                return Ok("Updated Aktivitet Deaktiveret");
            }
            return BadRequest("Der opstod en fejl. Prøv at check om aktiviteten allerede er aktiv.");
        }

        private bool AktivitetExists(int id)
        {
            return _context.Aktivitet.Any(e => e.AktivitetID == id);
        }
    }
}
