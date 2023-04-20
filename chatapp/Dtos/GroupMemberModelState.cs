using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace chatapp.Dtos
{
    public class GroupMemberModelState
    {
        [Required]
        public Guid contact_id { get; set; }

        [Required]
        public Guid conversation_id { get; set; }
    }
}
