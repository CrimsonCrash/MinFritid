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
using BC = BCrypt.Net.BCrypt;

namespace MinFritidAPI.Controllers
{
    [Route("api/bruger")]
    [EnableCors("AnotherPolicy")]
    [ApiController]
    public class BrugerController : ControllerBase
    {
        private MinFritidContext _context { get; }

        public BrugerController(MinFritidContext context)
        {
            _context = context;
        }

        // GET: api/Bruger
        [HttpGet]
        public IActionResult GetBrugere()
        {
            return new JsonResult(_context.Bruger);
        }

        // GET: api/Bruger/5
        [HttpGet("{id}")]
        public IActionResult GetBruger(int id)
        {
            var brugers = _context.Bruger;

            var bruger = brugers.Include("By").FirstOrDefault(Bruger => Bruger.ID == id);

            if (bruger == null)
            {
                return HttpNotFound();
            }

            return new JsonResult(bruger);
        }

        // PUT: api/Bruger/5
        [HttpPut("{id}")]
        public IActionResult PutBruger(int Id,[FromBody]Bruger bruger)
        {
            if (bruger == null)
            {
                return NotFound("Not found");
            }
            if (bruger.Postnummer != null)
            {
                var Postnummer = _context.By.Any(p => p.Postnummer == bruger.Postnummer);

                var putBruger = _context.Bruger.FirstOrDefault(i => i.ID == Id);
                
                if (Postnummer == true)
                {
                    bruger.Password = BC.HashPassword(bruger.Password);

                    putBruger.Fornavn = bruger.Fornavn;
                    putBruger.Efternavn = bruger.Efternavn;
                    putBruger.Foedselsdato = bruger.Foedselsdato;
                    putBruger.Postnummer = bruger.Postnummer;
                    putBruger.Email = bruger.Email;
                    putBruger.Password = bruger.Password;
                    _context.SaveChanges();
                    return Ok("Updated Bruger");
                }
            }
            /*var By = _context.By.FirstOrDefault(b => b.Postnummer == Id);
            if (bruger == null)
            {
                return NotFound("Not found");
            }
            if (bruger.BrugerID == Id)
            {
                _context.Bruger.Update(bruger);
                _context.SaveChanges();
                return Ok("Updated Bruger");
            }*/
            return BadRequest();
        }

        // POST: api/Bruger
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostBruger([FromBody] Bruger bruger)
        {
            using (var PostBruger = _context)
            {
                if (PostBruger != null)
                {
                    bruger.Password = BC.HashPassword(bruger.Password);

                    _context.Bruger.Add(bruger);
                    _context.SaveChanges();
                    return Ok("Added Bruger");
                }
                else
                {
                    return NotFound("Not added");
                }
            }
        }

        // DELETE: api/Bruger/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBruger(int id)
        {
            var DeleteBruger = _context.Bruger.FirstOrDefault(Bruger => Bruger.ID == id);
            if (DeleteBruger != null)
            {
                _context.Bruger.Remove(DeleteBruger);
                _context.SaveChanges();
                return Ok("Removed Bruger");
            }
            else
            {
                return NotFound("Not found");
            }
        }

        private bool BrugerExists(int id)
        {
            return _context.Bruger.Any(e => e.ID == id);
        }

        private IActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        // PUT: api/bruger/aktiv/5
        [HttpPut("aktiv/{id}")]
        public IActionResult AktiverBruger(int Id)
        {
            var bruger = _context.Bruger.FirstOrDefault(Bruger => Bruger.ID == Id);
            if (bruger == null)
            {
                return NotFound("Not found");
            }
            if (bruger.ID == Id)
            {
                bruger.Aktiv = true;
                _context.Bruger.Update(bruger);
                _context.SaveChanges();
                return Ok("Updated Bruger Aktiv");
            }
            return BadRequest();
        }

        // PUT: api/bruger/deaktiv/5
        [HttpPut("deaktiv/{id}")]
        public IActionResult DeaktiverBruger(int Id)
        {
            var bruger = _context.Bruger.FirstOrDefault(Bruger => Bruger.ID == Id);
            if (bruger == null)
            {
                return NotFound("Not found");
            }
            if (bruger.ID == Id)
            {
                bruger.Aktiv = false;
                _context.Bruger.Update(bruger);
                _context.SaveChanges();
                return Ok("Updated Bruger Deaktiveret");
            }
            return BadRequest();
        }

        // PUT: api/bruger/verify/5
        [HttpPut("verify/{id}")]
        public IActionResult VerificerBruger(int Id)
        {
            var bruger = _context.Bruger.FirstOrDefault(Bruger => Bruger.ID == Id);
            if (bruger == null)
            {
                return NotFound("Not found");
            }
            if (bruger.ID == Id)
            {
                bruger.Verificeret = true;
                _context.Bruger.Update(bruger);
                _context.SaveChanges();
                return Ok("Updated Bruger Verificeret");
            }
            return BadRequest();
        }

        
    }
}
