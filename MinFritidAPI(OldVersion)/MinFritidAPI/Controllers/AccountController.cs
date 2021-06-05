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
        //opsætter context
        private MinFritidContext _context { get; }

        public AccountController(MinFritidContext context)
        {
            _context = context;
        }

        // POST: api/account/login
        [HttpPost("login")]
        public bool Login([FromBody] Login login)
        {
            //login.Password = BC.HashPassword(login.Password);

            // Hent Bruger fra database
            var brugers = _context.Bruger;

            var bruger = brugers.Include("By").FirstOrDefault(Bruger => Bruger.Email == login.Email);

            //checker at passwords ikke matcher
            if (bruger == null || !BC.Verify(login.Password, bruger.Password))
            {
                ViewBag.error = "Invalid Email or Password";
                return false;
            }
            //Hvis passwords matcher, logges bruger ind
            else
            {
                var loggedIn = HttpContext.Session.GetInt32("LoggedOn");
                HttpContext.Session.SetInt32("LoggedOn",bruger.ID);
                System.Console.WriteLine("Session Created");
                return true;
            }
        }

        // Bruger bliver logget ud
        [HttpGet("logout")]
        public bool Logout()
        {
            HttpContext.Session.Remove("LoggedOn");
            System.Console.WriteLine("Session Closed");
            return false;
        }
    }
}