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
            this._service = service;
        }

        [HttpPost("/api/contact/create")]
        public async Task<IActionResult> Create([FromBody] ContactModelState contactMS)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            Guid id = await _service.ContactCreate(contactMS);
            if (id == Guid.Empty)
                return StatusCode(500);

            return Ok(id);
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
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            return Ok();
        }
    }
}
