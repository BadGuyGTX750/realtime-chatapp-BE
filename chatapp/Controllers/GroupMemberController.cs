﻿using chatapp.Dtos;
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
            _service = service;
            _contactService = contactService;
            _conversationService = conversationService;
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

            GroupMember grpMbCheck = await _service.GroupMemberGetByCoversationIdAndContactId(grpMbMS.conversation_id, grpMbMS.contact_id);
            if (grpMbCheck != null)
                return StatusCode(409, "The Contact has already a GroupMember associated with this conversation");

            //Check if conversation is a group: if it is make the first group member an admin (both original and admin)
            List<GroupMember> grpMbList = await _service.GroupMemberGetByCoversationId(grpMbMS.conversation_id);
            Conversation conv = await _conversationService.ConversationGetById(grpMbMS.conversation_id);
            bool isAllTimeAdmin = false;
            if (conv.isGroup && (grpMbList == null || !grpMbList.Any()))
                isAllTimeAdmin = true;
              

            Guid id = await _service.GroupMemberCreate(grpMbMS, isAllTimeAdmin, isAllTimeAdmin);
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
