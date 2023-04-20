using chatapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace chatapp.Controllers
{
    public class GroupMemberController : Controller
    {
        private readonly GroupMemberService _service;

        public GroupMemberController(GroupMemberService service)
        {
            this._service = service;
        }

        [HttpPost("/api/groupMember/create")]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }

        [HttpGet("/api/groupMember/getById")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            return Ok();
        }


        [HttpDelete("/api/groupMember/deleteById")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            return Ok();
        }
    }
}
