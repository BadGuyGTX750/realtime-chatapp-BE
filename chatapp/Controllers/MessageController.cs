using chatapp.Dtos;
using chatapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace chatapp.Controllers
{
    public class MessageController : Controller
    {
        private readonly MessageService _service;
        private readonly ConversationService _conversationService;

        public MessageController(MessageService service,
            ConversationService conversationService)
        {
            this._service = service;
            this._conversationService = conversationService;
        }

        [HttpPost("/api/message/create")]
        public async Task<IActionResult> Create([FromBody] MessageModelState msgMS)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _conversationService.ConversationGetById(msgMS.conversation_id) == null)
                return NotFound("No conversation with specified conversation_id exists");

            Guid id = await _service.MessageCreate(msgMS);
            if (id == Guid.Empty)
                return StatusCode(500);

            return Ok(id);
        }

        [HttpGet("/api/message/getById")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Message msg = await _service.MessageGetById(id);
            if (msg == null)
                return NotFound();

            return Ok(msg);
        }


        [HttpDelete("/api/message/deleteById")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            return Ok();
        }
    }
}
