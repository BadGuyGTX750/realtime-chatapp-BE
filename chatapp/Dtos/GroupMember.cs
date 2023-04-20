using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace chatapp.Dtos
{
    public class GroupMember
    {
        [Key]
        [Required]
        public Guid group_member_id { get; set; }

        [ForeignKey("contact")]
        [Required]
        public Guid contact_id { get; set; }

        [JsonIgnore]
        public Contact contact { get; set; }

        [ForeignKey("conversation")]
        [Required]
        public Guid conversation_id { get; set; }

        [JsonIgnore]
        public Conversation conversation { get; set; }

        [Required]
        public bool isOriginalGroupAdmin { get; set; } = false;

        [Required]
        public bool isGroupAdmin { get; set;} = false;

        [Required]
        public DateTime joined_datetime { get; set; }

        [Required]
        public DateTime left_datetime { get; set; }
    }
}
