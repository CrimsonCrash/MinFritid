﻿using System;
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
        public IActionResult PutBruger(int Id)
        {
            var PutBruger = _context.Bruger.FirstOrDefault(Bruger => Bruger.ID == Id);
            if (PutBruger != null)
            {
                _context.Bruger.Update(PutBruger);
                _context.SaveChanges();
                return Ok("Updated Bruger");
            }
            else
            {
                return NotFound("Not found");
            }
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
            var DeleteBruger = _context.Admin.FirstOrDefault(Bruger => Bruger.ID == id);
            if (DeleteBruger != null)
            {
                _context.Admin.Remove(DeleteBruger);
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
    }
}
