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
            var aktivitet = _context.Aktivitet;

            var AktivitetTemp = aktivitet.FirstOrDefault(Aktivitet => Aktivitet.AktivitetID == id);

            if (aktivitet == null)
            {
                return NotFound();
            }

            return new JsonResult(AktivitetTemp);
        }

        // PUT: api/Aktivitet/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
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

        private bool AktivitetExists(int id)
        {
            return _context.Aktivitet.Any(e => e.AktivitetID == id);
        }
    }
}
