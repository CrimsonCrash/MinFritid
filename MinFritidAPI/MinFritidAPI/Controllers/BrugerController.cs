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
            var users = _userManager.Users.Include("By").Select(b => new GetBrugerDto
            {
                BrugerID = b.Id,
                BrugerEmail = b.Email,
                BrugerFornavn = b.Fornavn,
                BrugerEfternavn = b.Efternavn,
                BrugerAktiv = b.Aktiv,
                BrugerVerificeret = b.Verificeret,
                BrugerFoedselsdag = b.Foedselsdato,
                BrugerBynavn = b.By.Bynavn
            });

            return new JsonResult(users);
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
        public async Task<IActionResult> PutBruger([FromBody]UpdateBrugerDto bruger) // TODO: Flyt til account
        {
            if (bruger == null)
            {
                return NotFound("Not found");
            }

            var Postnummer = _context.By.Any(p => p.Postnummer == bruger.BrugerPostnummer);
            var user = await _userManager.FindByIdAsync(bruger.Id);

            user.Fornavn = bruger.Fornavn;
            user.Efternavn = bruger.Efternavn;
            if (Postnummer == true)
            {
                user.BrugerPostnummer = bruger.BrugerPostnummer;
            }
            user.Foedselsdato = bruger.Foedselsdato;
            user.Email = bruger.Email;
            user.UserName = bruger.Email;
            user.PhoneNumber = bruger.PhoneNumber;
            user.SecurityStamp = bruger.SecurityStamp;
                
            var result = await _userManager.UpdateAsync(user);
            return Ok(result);
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
               }
        */

        // DELETE: api/Bruger
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBruger(string id)
        {
            var DeleteBruger = await _userManager.FindByIdAsync(id);
            if (DeleteBruger != null)
            {
                await _userManager.DeleteAsync(DeleteBruger);
                return Ok("Removed Bruger");
            }
            else
            {
                return NotFound("Not found");
            }
        }

        [HttpGet("test")]
        private bool BrugerExists(string id)
        {
            bool BrugerExists = _userManager.FindByIdAsync(id).Result.Id.Any();
            return _userManager.FindByIdAsync(id).Result.Id.Any();
        }

        private IActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        // PUT: api/bruger/aktiver
        [HttpPut("aktiver")]
        public async Task<IActionResult> AktiverBruger(VerificerAktiverBrugerDto aktiverBruger)
        {
            var bruger = await _userManager.FindByIdAsync(aktiverBruger.Id);
            if (bruger == null)
            {
                return NotFound("Brugeren blev ikke fundet");
            }
            else
            {
                bruger.Aktiv = aktiverBruger.NyeStatus;
                var result = await _userManager.UpdateAsync(bruger);
                return Ok(result);
            }
        }

        // PUT: api/bruger/verificer
        [HttpPut("verificer")]
        public async Task<IActionResult> VerificerBruger(VerificerAktiverBrugerDto verificerBruger)
        {
            var bruger = await _userManager.FindByIdAsync(verificerBruger.Id);
            if (bruger == null)
            {
                return NotFound("Brugeren blev ikke fundet");
            }
            else
            {
                bruger.Verificeret = verificerBruger.NyeStatus;
                var result = await _userManager.UpdateAsync(bruger);
                return Ok(result);
            }
        }
    }
}
