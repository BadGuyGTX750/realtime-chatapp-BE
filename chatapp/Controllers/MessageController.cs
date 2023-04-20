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
        public async Task<IActionResult> Create()
        {
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
