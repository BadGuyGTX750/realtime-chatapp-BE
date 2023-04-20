using chatapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace chatapp.Controllers
{
    public class ConversationController : Controller
    {
        private readonly ConversationService _service;

        public ConversationController(ConversationService service)
        {
            this._service = service;
        }

        [HttpPost("/api/conversation/create")]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }

        [HttpGet("/api/conversation/getById")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            return Ok();
        }


        [HttpDelete("/api/conversation/deleteById")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            return Ok();
        }
    }
}
