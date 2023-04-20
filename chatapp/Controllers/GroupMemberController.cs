using chatapp.Dtos;
using chatapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace chatapp.Controllers
{
    public class GroupMemberController : Controller
    {
        private readonly GroupMemberService _service;
        private readonly ContactService _contactService;
        private readonly ConversationService _conversationService;

        public GroupMemberController(GroupMemberService service,
            ContactService contactService,
            ConversationService conversationService)
        {
            this._service = service;
            this._contactService = contactService;
            this._conversationService = conversationService;
        }

        [HttpPost("/api/groupMember/create")]
        public async Task<IActionResult> Create([FromBody] GroupMemberModelState grpMbMS)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _contactService.ContactGetById(grpMbMS.contact_id) == null)
                return NotFound("No contact with specified contact_id exists");

            if (await _conversationService.ConversationGetById(grpMbMS.conversation_id) == null)
                return NotFound("No conversation with specified conversation_id exists");

            Guid id = await _service.GroupMemberCreate(grpMbMS);
            if (id == Guid.Empty)
                return StatusCode(500);

            return Ok(id);
        }

        [HttpGet("/api/groupMember/getById")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            GroupMember grpMb = await _service.GroupMemberGetById(id);
            if (grpMb == null)
                return NotFound();

            return Ok(grpMb);
        }


        [HttpDelete("/api/groupMember/deleteById")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _service.GroupMemberDeleteById(id))
                return StatusCode(500);

            return Ok();
        }
    }
}
