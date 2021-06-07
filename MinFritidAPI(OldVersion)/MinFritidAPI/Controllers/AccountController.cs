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
        public LoggedIn logged;

        //opsætter context
        private MinFritidContext _context { get; }

        public AccountController(MinFritidContext context)
        {
            _context = context;
        }

        // POST: api/account/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {
            //login.Password = BC.HashPassword(login.Password);
            logged = new LoggedIn();

            // Hent Bruger fra database
            var brugers = _context.Bruger;

            var bruger = brugers.Include("By").FirstOrDefault(Bruger => Bruger.Email == login.Email);

            //checker at passwords ikke matcher
            if (bruger == null || !BC.Verify(login.Password, bruger.Password))
            {
                return NotFound("Invalid Email or Password");
            }
            //Hvis passwords matcher, logges bruger ind
            else
            {
                logged.isLoggedIn = true;
                logged.LoginId = bruger.ID;
                var loggedIn = HttpContext.Session.GetInt32("LoggedOn");
                HttpContext.Session.SetInt32("LoggedOn",bruger.ID);
                System.Console.WriteLine("Session Created");
                return new JsonResult(logged);
            }
        }

        //checker om brugeren er logget ind
        [HttpGet("loggedIn")]
        public IActionResult LoggedIn(LoggedIn logged)
        {
            if (HttpContext.Session.GetInt32("LoggedOn") == logged.LoginId)
            {
                return new JsonResult(logged);
            }
            else
            {
                return NotFound("Du er blevet logget ud automatisk");
            }
            
        }

        // Bruger bliver logget ud
        [HttpGet("logout")]
        public bool Logout()
        {
            HttpContext.Session.Remove("LoggedOn");
            System.Console.WriteLine("Session Closed");
            logged.isLoggedIn = false;
            logged.LoginId = 0;
            return false;
        }
    }
}