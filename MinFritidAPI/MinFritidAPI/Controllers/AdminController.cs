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
    [Route("api/[controller]")]
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
        [HttpGet]
        public IActionResult GetAdmin()
        {
            return new JsonResult(_context.Admin);
        }

        // GET: api/Admin/5
        [HttpGet("{id}")]
        public IActionResult GetAdmins(int id)
        {
            var admin =  _context.Admin;

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }

        // POST: api/Admin
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
            var DeleteAdmin =  _context.Admin.FirstOrDefault(Admin => Admin.ID == id);
            if (DeleteAdmin != null)
            {
                    _context.Admin.Remove(DeleteAdmin);
                    _context.SaveChanges();
                    return Ok("Removed Book");
            }
            else
                {
            return NotFound("Not found");
            }

            
        }

        private bool AdminExists(int id)
        {
            return _context.Admin.Any(e => e.ID == id);
        }
    }
}
