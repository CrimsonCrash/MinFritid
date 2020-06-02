using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinFritidAPI.Data;
using MinFritidAPI.Models;

namespace MinFritidAPI.Controllers
{
    [Route("api/bruger")]
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

            var bruger = brugers.FirstOrDefault(Bruger => Bruger.ID == id);

            if (bruger == null)
            {
                return HttpNotFound();
            }

            return new JsonResult(bruger);
        }

        

        // PUT: api/Bruger/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBruger(int id, Bruger bruger)
        {
            if (id != bruger.ID)
            {
                return BadRequest();
            }

            _context.Entry(bruger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrugerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Bruger
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Bruger>> PostBruger(Bruger bruger)
        {
            _context.Bruger.Add(bruger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBruger", new { id = bruger.ID }, bruger);
        }

        // DELETE: api/Bruger/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bruger>> DeleteBruger(int id)
        {
            var bruger = await _context.Bruger.FindAsync(id);
            if (bruger == null)
            {
                return NotFound();
            }

            _context.Bruger.Remove(bruger);
            await _context.SaveChangesAsync();

            return bruger;
        }

        private bool BrugerExists(int id)
        {
            return _context.Bruger.Any(e => e.ID == id);
        }

        private IActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }
    }
}
