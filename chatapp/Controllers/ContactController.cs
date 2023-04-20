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
        public async Task<IActionResult> Create()
        {
            return Ok();
        }

        [HttpGet("/api/contact/getById")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            return Ok();
        }


        [HttpDelete("/api/contact/deleteById")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            return Ok();
        }
    }
}
