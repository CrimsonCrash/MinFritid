using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinFritidAPI.Data;
using MinFritidAPI.Models;
using BC = BCrypt.Net.BCrypt;

namespace MinFritidAPI.Controllers
{
    [Route("api/account")]
    [EnableCors("AnotherPolicy")]
    [ApiController]
    public class AccountController : Controller
    {

        private MinFritidContext _context { get; }

        public AccountController(MinFritidContext context)
        {
            _context = context;
        }

        // POST: api/account/login
        [HttpPost("login")]
        public ActionResult Login([FromBody] Login login)
        {
            
            
            // Hent Bruger fra database
            var brugers = _context.Bruger;

            var bruger = brugers.Include("By").FirstOrDefault(Bruger => Bruger.Email == login.Email);

            //checker at passwords matcher
            if (bruger == null || !BC.Verify(bruger.Password, login.Password))
            {
                ViewBag.error = "Invalid Email or Password";
                return View("Forside");
            }
            else
            {
                var loggedIn = HttpContext.Session.GetString("LoggedOn");
                HttpContext.Session.SetString("LoggedOn",loggedIn);
                return View();
            }

            

        }

        // Bruger bliver logget ud
        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("LoggedOn");
            return View();
        }
    }
}