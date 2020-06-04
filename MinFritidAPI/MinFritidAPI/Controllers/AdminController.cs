using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MinFritidAPI.Data;
using MinFritidAPI.Models;

namespace MinFritidAPI.Controllers
{
    [Route("api/admin")]
    [EnableCors("AnotherPolicy")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly MinFritidContext _context;

        public AdminController(MinFritidContext context)
        {
            _context = context;
        }

        // GET: api/Admin
        // Henter en liste over alle brugere der er admin
        [HttpGet]
        public IActionResult GetAllAdmins()
        {
            //var admins = _context.Admin;

            //MinFritidContext db = new MinFritidContext();

            var admins = from a in _context.Admin
                         join b in _context.Bruger on a.AdminID equals b.ID
                         select a;

            return new JsonResult(admins);
        }

        // GET: api/Admin/5
        // Henter én specifik admin
        // Fejler
        [HttpGet("{id}")]
        public IActionResult GetAdmin(int id)
        {
            var admins = _context.Admin;

            var admin = admins.FirstOrDefault(Admin => Admin.AdminID == id);

            if (admin == null)
            {
                return HttpNotFound();
            }

            return new JsonResult(admin);
        }

        // POST: api/Admin
        // Tilføj en ny bruger som admin
        [HttpPost]
        public IActionResult PostAdmin([FromBody]Admin admin)
        {
            using (var PostAdmin = _context)
            {

                if (PostAdmin != null)
                {
                    _context.Admin.Add(admin);
                    _context.SaveChanges();
                    return Ok("Added Admin");
                }
                else
                {
                    return NotFound("Not found");
                }
            }
        }

        // DELETE: api/Admin/5
        [HttpDelete("{ID}")]
        public IActionResult DeleteAdmin(int id)
        {
            var DeleteAdmin =  _context.Admin.FirstOrDefault(Admin => Admin.AdminID == id);
            if (DeleteAdmin != null)
            {
                    _context.Admin.Remove(DeleteAdmin);
                    _context.SaveChanges();
                    return Ok("Removed Admin");
            }
            else
                {
            return NotFound("Not found");
            }

            
        }

        private bool AdminExists(int id)
        {
            return _context.Admin.Any(e => e.AdminID == id);
        }

        private IActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }
    }
}
