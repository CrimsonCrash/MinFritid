using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCaching.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MinFritidAPI.Data;
using MinFritidAPI.Helpers;
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
        public bool Login([FromBody] Login login)
        {
            
            
            // Hent Bruger fra database
            var brugers = _context.Bruger;

            var bruger = brugers.Include("By").FirstOrDefault(Bruger => Bruger.Email == login.Email);

            if (bruger == null || !BC.Verify(bruger.Password, login.Password))
            {
                return false;
            }
            else
            {
                return true;
            }

            // Bruger bliver logget ind
            
        }
    }
}