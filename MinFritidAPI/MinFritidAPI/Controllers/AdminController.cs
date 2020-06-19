using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

        // GET: api/admin
        // Henter en liste over alle brugere der er admin
        [HttpGet]
        public IActionResult GetAllAdmins()
        {
            var admins = from a in _context.UserRoles
                         join b in _context.Bruger on a.UserId equals b.Id
                         select b;

            return new JsonResult(admins);
        }

        public UserManager<Bruger> userManager;

        // GET: api/admin/id
        // Henter én specifik admin ud fra BrugerID
        [HttpGet("{id}")]
        public IActionResult GetAdmin(string id)
        {
            
            var admins = from a in _context.UserRoles
                         join b in _context.Bruger on a.UserId equals b.Id
                         where a.UserId == id
                         select b;

            var admin = admins.FirstOrDefault();

            if (admin == null)
            {
                return HttpNotFound();
            }

            return new JsonResult(admin);
        }

        // POST: api/admin/id
        // Tilføj en ny bruger som admin ud fra BrugerID
        [HttpPost("{id}")]
        public IActionResult PostAdmin(string id)
        {
                var admins = from a in _context.UserRoles
                             join b in _context.Bruger on id equals b.Id
                             select b;

                var admin = admins.FirstOrDefault();

                if (admin != null)
                {
                /*_context.UserRoles.Add (new IdentityUserRole { UserId = id } );*/
                userManager.AddToRoleAsync(admin, "Admin");
                    _context.SaveChanges();
                    return Ok("Admin successfully created");
                }
                else
                {
                    return HttpNotFound();
                }
        }

        // DELETE: api/admin/id
        // Slet en bruger som admin ud fra BrugerID
        [HttpDelete("{id}")]
        public IActionResult DeleteAdmin(string id)
        {
            var admins = from a in _context.UserRoles
                         join b in _context.Bruger on a.UserId equals b.Id
                         where b.Id == id
                         select a;

            var admin = admins.FirstOrDefault();

            if (admin != null)
            {
                    _context.UserRoles.Remove(admin);
                    _context.SaveChanges();
                    return Ok("Admin successfully removed");
            }
            else
                {
            return HttpNotFound();
            }
        }

        private IActionResult HttpNotFound()
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Bad request");
        }
    }
}
