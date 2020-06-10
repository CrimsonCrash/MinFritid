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
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MinFritidAPI.Data;
using MinFritidAPI.Helpers;
using MinFritidAPI.Models;

namespace MinFritidAPI.Controllers
{
    [Route("api/account")]
    [EnableCors("AnotherPolicy")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly AppSettings _appSettings;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }




/*        private MinFritidContext _context { get; }

        public AccountController(MinFritidContext context)
        {
            _context = context;
        }*/

        // POST: api/account/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Register formdata)
        {
            // List med fejl i forbindelse med registrering
            List<string> errorList = new List<string>();

            var user = new IdentityUser
            {
                UserName = formdata.Email,
                Email = formdata.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, formdata.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Bruger");

                // Send Conf Email
                return Ok(new { user.Email, status = 1, message = "Bruger oprettet" });
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    errorList.Add(error.Description);
                }
            }

            return BadRequest(new JsonResult(errorList));
        }

        // POST: api/account/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login formdata)
        {
            // Hent Bruger fra database
            var user = await _userManager.FindByNameAsync(formdata.Email);

            var result = await _signInManager.PasswordSignInAsync(user, formdata.Password, isPersistent: true, lockoutOnFailure: true);

            var roles = await _userManager.GetRolesAsync(user);

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.Secret));

            double tokenExpiryTime = Convert.ToDouble(_appSettings.ExpireTime);

            //if (user != null && await _userManager.CheckPasswordAsync(user, formdata.Password))
            if (result.Succeeded)
            {
                // Conf Email

                // JWT logik
                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, formdata.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.NameIdentifier, user.Id),
                        new Claim(ClaimTypes.Role, roles.FirstOrDefault()),
                        new Claim("LoggedOn", DateTime.Now.ToString()),

                    }),

                    SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                    Issuer = _appSettings.Site,
                    Audience = _appSettings.Audience,
                    Expires = DateTime.UtcNow.AddMinutes(tokenExpiryTime)
                };

                // Opret JWT token til clienten
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(new { token = tokenHandler.WriteToken(token), expiration = token.ValidTo, email = user.Email, userRole = roles.FirstOrDefault() });
            }
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Account is locked out");
                return Unauthorized(new { LoginError = "You've been locked out fool" });
            }
            {

            }

            // Bruger ikke fundet
            ModelState.AddModelError("", "Email/Password was not found");
            return Unauthorized(new { LoginError = "Please check the login credentials" });
        }
    }
}