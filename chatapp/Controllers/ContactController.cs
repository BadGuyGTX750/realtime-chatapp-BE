using BCrypt.Net;
using chatapp.Dtos;
using chatapp.Repositories;
using chatapp.Services;
using Microsoft.AspNetCore.Mvc;


namespace chatapp.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactService _service;

        public ContactController(ContactService service)
        {
            _service = service;
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
