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

        public BrugerController(UserManager<Bruger> userManager, MinFritidContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: api/Bruger
        [HttpGet]
        public IActionResult GetBrugere()
        {
            var temp = _userManager.Users.Include("By");
            return new JsonResult(temp);
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
        public async Task<IActionResult> PutBruger(Bruger bruger)
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
 /*       [HttpPost]
        public async Task<IActionResult> PostBruger(CreateBrugerDto brugerDto)
        {
            if (ModelState.IsValid)
            {
                Bruger bruger = new Bruger
                {
                    UserName = brugerDto.UserName,
                    Email = brugerDto.Email,
                    Fornavn = brugerDto.Fornavn,
                    Efternavn = brugerDto.Efternavn,
                    BrugerPostnummer = brugerDto.Postnummer,
                    Foedselsdato = brugerDto.Foedselsdag,
                    PhoneNumber = brugerDto.PhoneNumber
                };

                IdentityResult result = await _userManager.CreateAsync(bruger, brugerDto.Password);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }*/

        // DELETE: api/Bruger
        [HttpDelete]
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

        // PUT: api/bruger/aktiv
        [HttpPut("aktiv")]
        public async Task<IActionResult> AktiverBruger(string Id)
        {
            var bruger = _userManager.FindByIdAsync(Id).Result;
            if (bruger == null)
            {
                return NotFound("Not found");
            }
            else
            {
                bruger.Aktiv = true;
                await _userManager.UpdateAsync(bruger);
                return Ok("Updated Bruger Aktiv");
            }
        }

        // PUT: api/bruger/deaktiv
        [HttpPut("deaktiv")]
        public async Task<IActionResult> DeaktiverBruger(string Id)
        {
            var bruger = _userManager.FindByIdAsync(Id).Result;
            if (bruger == null)
            {
                return NotFound("Not found");
            }
            else
            {
                bruger.Aktiv = false;
                await _userManager.UpdateAsync(bruger);
                return Ok("Updated Bruger Aktiv");
            }
        }

        // PUT: api/bruger/verify
        [HttpPut("verify")]
        public async Task<IActionResult> VerificerBruger(string Id, bool nyeStatus)
        {
            var bruger = _userManager.FindByIdAsync(Id).Result;
            if (bruger == null)
            {
                return NotFound("Not found");
            }
            else
            {
                bruger.Verificeret = nyeStatus;
                await _userManager.UpdateAsync(bruger);
                return Ok("Updated Bruger Aktiv");
            }
        }
    }
}
