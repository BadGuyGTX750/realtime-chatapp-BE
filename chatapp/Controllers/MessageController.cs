using chatapp.Dtos;
using chatapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace chatapp.Controllers
{
    public class MessageController : Controller
    {
        private readonly MessageService _service;

        public MessageController(MessageService service)
        {
            this._service = service;
        }

        [HttpPost("/api/message/create")]
        public async Task<IActionResult> Create([FromBody] MessageModelState msgMS)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Guid id = await _service.MessageCreate(msgMS);
            if (id == Guid.Empty)
                return StatusCode(500);

            return Ok();
        }

        [HttpGet("/api/message/getById")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            return Ok();
        }


        [HttpDelete("/api/message/deleteById")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            return Ok();
        }
    }
}
