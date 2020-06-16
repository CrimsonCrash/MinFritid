using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinFritidAPI.Data;

namespace MinFritidAPI.Controllers
{
    [Route("api/by")]
    [EnableCors("AnotherPolicy")]
    [ApiController]
    public class ByController : Controller
    {
        private readonly MinFritidContext _context;

        public ByController(MinFritidContext context)
        {
            _context = context;
        }

        // GET: By
        [HttpGet]
        public IActionResult GetByer()
        {
            return new JsonResult(_context.By);
        }

        // GET: By/Details/5
        // Returnerer Bynavn ud fra Postnummer
        [HttpGet("{PostNummer}")]
        public IActionResult GetBynavnByPostNr(int Postnummer)
        {
            var byer = _context.By;

            var by = byer.FirstOrDefault(By => By.Postnummer == Postnummer);

            if (by == null)
            {
                return HttpNotFound();
            }

            return new JsonResult(by.Bynavn);
        }

        private IActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }
    }
}