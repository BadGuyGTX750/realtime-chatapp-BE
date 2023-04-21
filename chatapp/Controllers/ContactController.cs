using chatapp.Dtos;
using chatapp.Infrastructure.Services;
using chatapp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace chatapp.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactService _service;
        private readonly JWTTokenGenerator _jwtTokenGenerator;
        private readonly CookieOptions _cookieOptions;

        public ContactController(ContactService service,
            JWTTokenGenerator jwtTokenGenerator)
        {
            _service = service;
            _jwtTokenGenerator = jwtTokenGenerator;
            _cookieOptions = new CookieOptions
            {
                HttpOnly = false,
                Secure = true,
                SameSite = SameSiteMode.None
            };
        }

        [HttpPost("/api/contact/register")]
        public async Task<IActionResult> Register([FromBody] ContactModelState contactMS)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            Contact contactTmp = await _service.ContactGetByEmail(contactMS.email);
            if (contactTmp != null)
                return StatusCode(409, "Email adress already used");

            if (!contactMS.password.Equals(contactMS.confirm_password))
                return BadRequest("Password fields don't match");

            contactMS.password = BCrypt.Net.BCrypt.HashPassword(contactMS.password);
            Guid id = await _service.ContactCreate(contactMS);
            if (id == Guid.Empty)
                return StatusCode(500);

            return Ok(id);
        }

        [HttpPost("/api/contact/login")]
        public async Task<IActionResult> Login([FromBody] LoginModelState credentials)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var contact = await _service.ContactGetByEmail(credentials.email);
            if (contact == null)
                return NotFound("Account does not exist");

            if (!BCrypt.Net.BCrypt.Verify(credentials.password, contact.password))
                return BadRequest("Bad credentials");

            // create claims for the logged in user
            ClaimsIdentity claimsIdentity = _jwtTokenGenerator.CreateClaimsIdentity(contact);

            // give the user a token based on his Identity
            string token = _jwtTokenGenerator.GenerateToken(claimsIdentity);
            Response.Cookies.Append("realtime-chatapp-access-token", token, _cookieOptions);

            return Ok();
        }

        [HttpPost("/api/contact/logout")]
        public async Task<IActionResult> Logout()
        {
            // Set the cookies to expire in the past
            CookieOptions ckOpt = _cookieOptions;
            ckOpt.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Append("realtime-chatapp-access-token", "", ckOpt);

            return Ok();
        }

        [HttpGet("/api/contact/getById")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Contact contact = await _service.ContactGetById(id);
            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [HttpGet("/api/contact/getClaims")]
        public async Task<IActionResult> GetClaims()
        {
            var claimsDict = _jwtTokenGenerator.GetClaimsToDict(Request.Cookies["realtime-chatapp-access-token"]);
            return Ok(claimsDict);
        }


        [HttpDelete("/api/contact/deleteById")]
        public async Task<IActionResult> DeleteById([FromQuery] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _service.ContactDeleteById(id))
                return StatusCode(500);

            return Ok();
        }
    }
}
