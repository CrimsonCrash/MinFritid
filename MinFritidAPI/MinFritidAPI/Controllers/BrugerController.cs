using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinFritidAPI.Data;
using MinFritidAPI.Models;

namespace MinFritidAPI.Controllers
{
    [Route("api/bruger")]
    [EnableCors("AnotherPolicy")]
    [ApiController]
    public class BrugerController : ControllerBase
    {
        private readonly UserManager<Bruger> _userManager;
        private MinFritidContext _context { get; }

        public BrugerController(UserManager<Bruger> userManager)
        {
            _userManager = userManager;
        }

/*        public BrugerController(MinFritidContext context)
        {
            _context = context;
        }*/

        // GET: api/Bruger
        [HttpGet]
        public IActionResult GetBrugere()
        {
            return new JsonResult(_context.Bruger);
        }

        // GET: api/Bruger/5
        [HttpGet("{id}")]
        public IActionResult GetBruger(string id)
        {
            var brugers = _context.Bruger;

            var bruger = brugers.Include("By").FirstOrDefault(Bruger => Bruger.Id == id);

            if (bruger == null)
            {
                return HttpNotFound();
            }

            return new JsonResult(bruger);
        }

        // PUT: api/Bruger
        [HttpPut]
        public async Task<IActionResult> PutBruger(int Id, Bruger bruger)
        {
            if (bruger == null)
            {
                return NotFound("Not found");
            }
            if (bruger.BrugerPostnummer != null) // TODO: Look into this
            {
                var Postnummer = _context.By.Any(p => p.Postnummer == bruger.BrugerPostnummer);
                
                if (Postnummer == true)
                {
                    await _userManager.UpdateAsync(bruger);
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
        public async Task<IActionResult> PostBruger([FromBody] Bruger bruger)
        {
            using (var PostBruger = _context)
            {
                if (PostBruger != null)
                {
                    await _userManager.CreateAsync(bruger);
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
        public IActionResult DeleteBruger(string id)
        {
            var DeleteBruger = _context.Bruger.FirstOrDefault(Bruger => Bruger.Id == id);
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

        private bool BrugerExists(string id)
        {
            return _context.Bruger.Any(e => e.Id == id);
        }

        private IActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        // PUT: api/bruger/aktiv/5
        [HttpPut("aktiv/{id}")]
        public IActionResult AktiverBruger(string Id)
        {
            var bruger = _context.Bruger.FirstOrDefault(Bruger => Bruger.Id == Id);
            if (bruger == null)
            {
                return NotFound("Not found");
            }
            if (bruger.Id == Id)
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
        public IActionResult DeaktiverBruger(string Id)
        {
            var bruger = _context.Bruger.FirstOrDefault(Bruger => Bruger.Id == Id);
            if (bruger == null)
            {
                return NotFound("Not found");
            }
            if (bruger.Id == Id)
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
        public IActionResult VerificerBruger(string Id)
        {
            var bruger = _context.Bruger.FirstOrDefault(Bruger => Bruger.Id == Id);
            if (bruger == null)
            {
                return NotFound("Not found");
            }
            if (bruger.Id == Id)
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
