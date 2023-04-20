using chatapp.Dtos;
using chatapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace chatapp.Controllers
{
    public class ConversationController : Controller
    {
        private readonly ConversationService _service;

        public ConversationController(ConversationService service)
        {
            _service = service;
        }

        [HttpPost("/api/conversation/create")]
        public async Task<IActionResult> Create([FromBody] ConversationModelState convMS)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Guid id = await _service.ConversationCreate(convMS);
            if (id == Guid.Empty)
                return StatusCode(500);

            return Ok(id);
        }

        [HttpGet("/api/conversation/getById")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Conversation conv = await _service.ConversationGetById(id);
            if (conv == null)
                return NotFound();

            return Ok(conv);
        }


        [HttpDelete("/api/conversation/deleteById")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _service.ConversationDeleteById(id))
                return StatusCode(500);

            return Ok();
        }
    }
}
